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
    public class GP_SettingsController : Controller
    {
        private readonly Supervise_Context _context;

        public GP_SettingsController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: GP_Settings
        public async Task<IActionResult> Index()
        {
              return _context.GP_Settings != null ? 
                          View(await _context.GP_Settings.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.GP_Settings'  is null.");
        }

        // GET: GP_Settings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GP_Settings == null)
            {
                return NotFound();
            }

            var gP_Settings = await _context.GP_Settings
                .FirstOrDefaultAsync(m => m.id == id); ; ; ; ; ; ; ; ; ;
            if (gP_Settings == null)
            {
                return NotFound();
            }

            return View(gP_Settings);
        }

        // GET: GP_Settings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GP_Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Max_students_number,Min_students_number,Num_of_male_groups,Num_of_female_groups,Dr_supervision_limit,Ms_supervision_limit,MF_supervision_limit,Term1_SubmissionDeadline,Term2_SubmissionDeadline")] GP_Settings gP_Settings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gP_Settings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gP_Settings);
        }

        // GET: GP_Settings/Edit/5
        public async Task<IActionResult> Edit()
        {
            int id = 1;

            var gP_Settings = await _context.GP_Settings.FindAsync(id);
            if (gP_Settings == null)
            {
                return NotFound();
            }
            return View(gP_Settings);
        }

        // POST: GP_Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Max_students_number,Min_students_number,Num_of_male_groups,Num_of_female_groups,Dr_supervision_limit,Ms_supervision_limit,MF_supervision_limit,Term1_SubmissionDeadline,Term2_SubmissionDeadline")] GP_Settings gP_Settings)
        {
            if (id != gP_Settings.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gP_Settings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GP_SettingsExists(gP_Settings.id))
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
            return View(gP_Settings);
        }

        // GET: GP_Settings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GP_Settings == null)
            {
                return NotFound();
            }

            var gP_Settings = await _context.GP_Settings
                .FirstOrDefaultAsync(m => m.id == id);
            if (gP_Settings == null)
            {
                return NotFound();
            }

            return View(gP_Settings);
        }

        // POST: GP_Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GP_Settings == null)
            {
                return Problem("Entity set 'Supervise_Context.GP_Settings'  is null.");
            }
            var gP_Settings = await _context.GP_Settings.FindAsync(id);
            if (gP_Settings != null)
            {
                _context.GP_Settings.Remove(gP_Settings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GP_SettingsExists(int id)
        {
          return (_context.GP_Settings?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
