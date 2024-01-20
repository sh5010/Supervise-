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
    public class Sp_studentgroupingController : Controller
    {
        private readonly Supervise_Context _context;

        public Sp_studentgroupingController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: Sp_studentgrouping
        public async Task<IActionResult> Index()
        {
              return _context.Sp_studentgrouping != null ? 
                          View(await _context.Sp_studentgrouping.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.Sp_studentgrouping'  is null.");
        }

        // GET: Sp_studentgrouping/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sp_studentgrouping == null)
            {
                return NotFound();
            }

            var sp_studentgrouping = await _context.Sp_studentgrouping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_studentgrouping == null)
            {
                return NotFound();
            }

            return View(sp_studentgrouping);
        }

        // GET: Sp_studentgrouping/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sp_studentgrouping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Group_id,Student_Name,Student_Status")] Sp_studentgrouping sp_studentgrouping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sp_studentgrouping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sp_studentgrouping);
        }

        // GET: Sp_studentgrouping/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sp_studentgrouping == null)
            {
                return NotFound();
            }

            var sp_studentgrouping = await _context.Sp_studentgrouping.FindAsync(id);
            if (sp_studentgrouping == null)
            {
                return NotFound();
            }
            return View(sp_studentgrouping);
        }

        // POST: Sp_studentgrouping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Group_id,Student_Name,Student_Status")] Sp_studentgrouping sp_studentgrouping)
        {
            if (id != sp_studentgrouping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_studentgrouping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sp_studentgroupingExists(sp_studentgrouping.Id))
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
            return View(sp_studentgrouping);
        }

        // GET: Sp_studentgrouping/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sp_studentgrouping == null)
            {
                return NotFound();
            }

            var sp_studentgrouping = await _context.Sp_studentgrouping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_studentgrouping == null)
            {
                return NotFound();
            }

            return View(sp_studentgrouping);
        }

        // POST: Sp_studentgrouping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sp_studentgrouping == null)
            {
                return Problem("Entity set 'Supervise_Context.Sp_studentgrouping'  is null.");
            }
            var sp_studentgrouping = await _context.Sp_studentgrouping.FindAsync(id);
            if (sp_studentgrouping != null)
            {
                _context.Sp_studentgrouping.Remove(sp_studentgrouping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sp_studentgroupingExists(int id)
        {
          return (_context.Sp_studentgrouping?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
