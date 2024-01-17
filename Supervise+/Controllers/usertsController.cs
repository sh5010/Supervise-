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
    public class usertsController : Controller
    {
        private readonly Supervise_Context _context;

        public usertsController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: userts
        public async Task<IActionResult> Index()
        {
              return _context.usert != null ? 
                          View(await _context.usert.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.usert'  is null.");
        }

        // GET: userts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.usert == null)
            {
                return NotFound();
            }

            var usert = await _context.usert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usert == null)
            {
                return NotFound();
            }

            return View(usert);
        }

        // GET: userts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: userts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Gender,Role")] usert usert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usert);
        }

        // GET: userts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.usert == null)
            {
                return NotFound();
            }

            var usert = await _context.usert.FindAsync(id);
            if (usert == null)
            {
                return NotFound();
            }
            return View(usert);
        }

        // POST: userts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Gender,Role")] usert usert)
        {
            if (id != usert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!usertExists(usert.Id))
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
            return View(usert);
        }

        // GET: userts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.usert == null)
            {
                return NotFound();
            }

            var usert = await _context.usert
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usert == null)
            {
                return NotFound();
            }

            return View(usert);
        }

        // POST: userts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.usert == null)
            {
                return Problem("Entity set 'Supervise_Context.usert'  is null.");
            }
            var usert = await _context.usert.FindAsync(id);
            if (usert != null)
            {
                _context.usert.Remove(usert);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool usertExists(int id)
        {
          return (_context.usert?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
