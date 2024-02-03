using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Supervise_.Data;
using Supervise_.Models;

namespace Supervise_.Controllers
{
    public class sp_faculity_rolesController : Controller
    {
        private readonly Supervise_Context _context;

        public sp_faculity_rolesController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_faculity_roles
        public async Task<IActionResult> Index()
        {
              return _context.sp_faculity_roles != null ? 
                          View(await _context.sp_faculity_roles.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.sp_faculity_roles'  is null.");
        }

        // GET: sp_faculity_roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_faculity_roles == null)
            {
                return NotFound();
            }

            var sp_faculity_roles = await _context.sp_faculity_roles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sp_faculity_roles == null)
            {
                return NotFound();
            }

            return View(sp_faculity_roles);
        }

        // GET: sp_faculity_roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_faculity_roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,InstructorName,Supervisor,Examiner")] sp_faculity_roles sp_faculity_roles)
        {
           
                _context.Add(sp_faculity_roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         

        // GET: sp_faculity_roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sp_faculity_roles == null)
            {
                return NotFound();
            }

            var sp_faculity_roles = await _context.sp_faculity_roles.FindAsync(id);
            if (sp_faculity_roles == null)
            {
                return NotFound();
            }
            return View(sp_faculity_roles);
        }

        // POST: sp_faculity_roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,InstructorName,Supervisor,Examiner")] sp_faculity_roles sp_faculity_roles)
        {
            if (id != sp_faculity_roles.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_faculity_roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sp_faculity_rolesExists(sp_faculity_roles.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sp_faculity_roles);
        }

        // GET: sp_faculity_roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sp_faculity_roles == null)
            {
                return NotFound();
            }

            var sp_faculity_roles = await _context.sp_faculity_roles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sp_faculity_roles == null)
            {
                return NotFound();
            }

            return View(sp_faculity_roles);
        }

        // POST: sp_faculity_roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_faculity_roles == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_faculity_roles'  is null.");
            }
            var sp_faculity_roles = await _context.sp_faculity_roles.FindAsync(id);
            if (sp_faculity_roles != null)
            {
                _context.sp_faculity_roles.Remove(sp_faculity_roles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_faculity_rolesExists(int id)
        {
          return (_context.sp_faculity_roles?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
