using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Supervise_.Data;
using Supervise_.Models;

namespace Supervise_.Controllers
{
    public class sp_gp_settingController : Controller
    {
        private readonly Supervise_Context _context;;

        public sp_gp_settingController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_gp_setting
        public async Task<IActionResult> Index()
        {
              return _context.sp_gp_setting != null ? 
                          View(await _context.sp_gp_setting.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.sp_gp_setting'  is null.");
        }

        // GET: sp_gp_setting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_gp_setting == null)
            {
                return NotFound();
            }

            var sp_gp_setting = await _context.sp_gp_setting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_gp_setting == null)
            {
                return NotFound();
            }

            return View(sp_gp_setting);
        }

        // GET: sp_gp_setting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_gp_setting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Max_st_num,Min_st_num,Num_male_grp,Num_female_grp,Dr_supr_limit,Ms_supr_limit,M_F_supr_limit,Term1_Subm_deadline,Term2_Subm_deadline")] sp_gp_setting sp_gp_setting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sp_gp_setting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sp_gp_setting);
        }

        // GET: sp_gp_setting/Edit/5
        public async Task<IActionResult> Edit()
        {
            int id = 2;

            var sp_gp_setting = await _context.sp_gp_setting.FindAsync(id);
            if (sp_gp_setting == null)
            {
                return NotFound();
            }
            return View(sp_gp_setting);
        }

        // POST: sp_gp_setting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Max_st_num,Min_st_num,Num_male_grp,Num_female_grp,Dr_supr_limit,Ms_supr_limit,M_F_supr_limit,Term1_Subm_deadline,Term2_Subm_deadline")] sp_gp_setting sp_gp_setting)
        {
            if (id != sp_gp_setting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_gp_setting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sp_gp_settingExists(sp_gp_setting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("sthome", "Home"); 
            }
            return View(sp_gp_setting);
        }

        // GET: sp_gp_setting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sp_gp_setting == null)
            {
                return NotFound();
            }

            var sp_gp_setting = await _context.sp_gp_setting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_gp_setting == null)
            {
                return NotFound();
            }

            return View(sp_gp_setting);
        }

        // POST: sp_gp_setting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_gp_setting == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_gp_setting'  is null.");
            }
            var sp_gp_setting = await _context.sp_gp_setting.FindAsync(id);
            if (sp_gp_setting != null)
            {
                _context.sp_gp_setting.Remove(sp_gp_setting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_gp_settingExists(int id)
        {
          return (_context.sp_gp_setting?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
