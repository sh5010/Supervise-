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
    public class facultysController : Controller
    {
        private readonly Supervise_Context _context;

        public facultysController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: facultys
        public async Task<IActionResult> Index()
        {
              return _context.facultys != null ? 
                          View(await _context.facultys.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.facultys'  is null.");
        }

        // GET: facultys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.facultys == null)
            {
                return NotFound();
            }

            var facultys = await _context.facultys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultys == null)
            {
                return NotFound();
            }

            return View(facultys);
        }

        // GET: facultys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: facultys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year,Phone_Number,Group_Count,Background,interests,ideas")] facultys facultys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultys);
        }

        // GET: facultys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.facultys == null)
            {
                return NotFound();
            }

            var facultys = await _context.facultys.FindAsync(id);
            if (facultys == null)
            {
                return NotFound();
            }
            return View(facultys);
        }

        // POST: facultys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Phone_Number,Group_Count,Background,interests,ideas")] facultys facultys)
        {
            if (id != facultys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!facultysExists(facultys.Id))
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
            return View(facultys);
        }

        // GET: facultys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.facultys == null)
            {
                return NotFound();
            }

            var facultys = await _context.facultys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultys == null)
            {
                return NotFound();
            }

            return View(facultys);
        }

        // POST: facultys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.facultys == null)
            {
                return Problem("Entity set 'Supervise_Context.facultys'  is null.");
            }
            var facultys = await _context.facultys.FindAsync(id);
            if (facultys != null)
            {
                _context.facultys.Remove(facultys);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool facultysExists(int id)
        {
          return (_context.facultys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
