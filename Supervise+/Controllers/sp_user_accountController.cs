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
    public class sp_user_accountController : Controller
    {
        private readonly Supervise_Context _context;

        public sp_user_accountController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_user_account
        public async Task<IActionResult> Index()
        {
              return _context.sp_user_account != null ? 
                          View(await _context.sp_user_account.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.sp_user_account'  is null.");
        }

        // GET: sp_user_account/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_user_account == null)
            {
                return NotFound();
            }

            var sp_user_account = await _context.sp_user_account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_user_account == null)
            {
                return NotFound();
            }

            return View(sp_user_account);
        }

        // GET: sp_user_account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_user_account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Role")] sp_user_account sp_user_account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sp_user_account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sp_user_account);
        }

        // GET: sp_user_account/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sp_user_account == null)
            {
                return NotFound();
            }

            var sp_user_account = await _context.sp_user_account.FindAsync(id);
            if (sp_user_account == null)
            {
                return NotFound();
            }
            return View(sp_user_account);
        }

        // POST: sp_user_account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Password,Role")] sp_user_account sp_user_account)
        {
            if (id != sp_user_account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_user_account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sp_user_accountExists(sp_user_account.Id))
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
            return View(sp_user_account);
        }

        // GET: sp_user_account/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sp_user_account == null)
            {
                return NotFound();
            }

            var sp_user_account = await _context.sp_user_account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_user_account == null)
            {
                return NotFound();
            }

            return View(sp_user_account);
        }

        // POST: sp_user_account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_user_account == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_user_account'  is null.");
            }
            var sp_user_account = await _context.sp_user_account.FindAsync(id);
            if (sp_user_account != null)
            {
                _context.sp_user_account.Remove(sp_user_account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_user_accountExists(int id)
        {
          return (_context.sp_user_account?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
