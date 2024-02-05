using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Supervise_.Data;
using Supervise_.Models;

namespace Supervise_.Controllers
{
    public class sp_GP_GroupController : Controller
    {
        private readonly Supervise_Context _context;

        public sp_GP_GroupController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_GP_Group
        public async Task<IActionResult> Index()
        {
              return _context.sp_GP_Group != null ? 
                          View(await _context.sp_GP_Group.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.sp_GP_Group'  is null.");
        }

        public async Task<IActionResult> MyIndex()
        {
            string na = (HttpContext.Session.GetString("Name"));
            var grst = await _context.sp_GP_Group.FromSqlRaw("select * from sp_GP_Group where Supervisor_Name = '" + na + "' AND statue = 'Supervisor Wait'").ToListAsync();

            return View(grst);
        }

        // GET: sp_GP_Group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_GP_Group == null)
            {
                return NotFound();
            }

            var sp_GP_Group = await _context.sp_GP_Group
                .FirstOrDefaultAsync(m => m.id == id);
            if (sp_GP_Group == null)
            {
                return NotFound();
            }

            return View(sp_GP_Group);
        }

        // GET: sp_GP_Group/Create
        public async Task<IActionResult> Create()

        {   
            var grst = await _context.sp_gp_setting.FromSqlRaw("select * from sp_gp_setting where Id = 2").FirstOrDefaultAsync(); 

             int drl =  grst.Dr_supr_limit;
             int msl = grst.Ms_supr_limit;

             var li = await _context.sp_instructor.FromSqlRaw("select * from sp_instructor where (Group_Count < '"+drl+ "' and rank = 'Doctor') or (Group_Count < '"+msl+"' and rank = 'Master')").ToListAsync(); ;
            ViewBag.Superv = li;

            return View();
        }

        // POST: sp_GP_Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Supervisor_Name,sthead_name,Year,Project_Project_ProblemDefinition,Project_scope,Project_title,Project_Objective,statue,Registration_code,MassegeToSupervisor")] sp_GP_Group sp_GP_Group)
        {
            if (sp_GP_Group.Project_Project_ProblemDefinition == null) sp_GP_Group.Project_Project_ProblemDefinition = String.Empty;
            if (sp_GP_Group.Project_scope == null) sp_GP_Group.Project_scope = String.Empty;
            if (sp_GP_Group.Project_Objective == null) sp_GP_Group.Project_Objective = String.Empty;

            string stname = (HttpContext.Session.GetString("Name"));
            var cgp = await _context.sp_GP_Group.Where(m => m.sthead_name == stname).FirstOrDefaultAsync();
            if (cgp == null)
            {
                sp_GP_Group.sthead_name = stname;
                int yy = DateTime.Today.Year;
                int mm = DateTime.Today.Month;
                if (mm < 8) {
                    yy = yy - 1;  // 5/2023 belong to 2022
                }

                var st = await _context.sp_student.Where(m => m.Name == stname).FirstOrDefaultAsync();

                sp_GP_Group.gender = st.Gender;
                sp_GP_Group.Year = yy;
                sp_GP_Group.statue = "Supervisor Wait";
                sp_GP_Group.Registration_code = "0";
                _context.Add(sp_GP_Group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else
            {
                ViewData["Message"] = "You can not Create two Groups.";
                List<sp_instructor> li = new List<sp_instructor>(); // avoid error
                ViewBag.Superv = li;
                return View();
            }
           

        }
    

        // GET: sp_GP_Group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var grst = await _context.sp_gp_setting.FromSqlRaw("select * from sp_gp_setting where Id = 2").FirstOrDefaultAsync(); ;

            int drl = grst.Dr_supr_limit;
            int msl = grst.Ms_supr_limit;

            var li = await _context.sp_instructor.FromSqlRaw("select * from sp_instructor where (Group_Count < '" + drl + "' and rank = 'Doctor') or (Group_Count < '" + msl + "' and rank = 'Master')").ToListAsync(); ;
            ViewBag.Superv = li;

            if (id == null || _context.sp_GP_Group == null)
            {
                return NotFound();
            }

            var sp_GP_Group = await _context.sp_GP_Group.FindAsync(id);
            if (sp_GP_Group == null)
            {
                return NotFound();
            }
            if (sp_GP_Group.Project_Project_ProblemDefinition == null) sp_GP_Group.Project_Project_ProblemDefinition = String.Empty;
            if (sp_GP_Group.Project_scope == null) sp_GP_Group.Project_scope = String.Empty;
            if (sp_GP_Group.Project_Objective == null) sp_GP_Group.Project_Objective = String.Empty;
            if (sp_GP_Group.MassegeToSupervisor==null) sp_GP_Group.MassegeToSupervisor = String.Empty;
            return View(sp_GP_Group);
        }

        // POST: sp_GP_Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Supervisor_Name,sthead_name,Year,Project_Project_ProblemDefinition,Project_scope,Project_title,Project_Objective,statue,Registration_code,gender,MassegeToSupervisor")] sp_GP_Group sp_GP_Group)
        {
           
                    _context.Update(sp_GP_Group);
                    await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
           
        }

        // GET: sp_GP_Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sp_GP_Group == null)
            {
                return NotFound();
            }

            var sp_GP_Group = await _context.sp_GP_Group
                .FirstOrDefaultAsync(m => m.id == id);
            if (sp_GP_Group == null)
            {
                return NotFound();
            }

            return View(sp_GP_Group);
        }

        // POST: sp_GP_Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_GP_Group == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_GP_Group'  is null.");
            }
            var sp_GP_Group = await _context.sp_GP_Group.FindAsync(id);
            if (sp_GP_Group != null)
            {
                _context.sp_GP_Group.Remove(sp_GP_Group);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_GP_GroupExists(int id)
        {
          return (_context.sp_GP_Group?.Any(e => e.id == id)).GetValueOrDefault();
        }


     

    }
}
