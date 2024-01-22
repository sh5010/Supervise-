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
    public class sp_studentController : Controller
    {
        private readonly Supervise_Context _context;

        public sp_studentController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_student
        public async Task<IActionResult> Index()
        {
              return _context.sp_student != null ? 
                          View(await _context.sp_student.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.sp_student'  is null.");
        }

        // GET: sp_student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_student == null)
            {
                return NotFound();
            }

            var sp_student = await _context.sp_student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_student == null)
            {
                return NotFound();
            }

            return View(sp_student);
        }

        // GET: sp_student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Email,Phone,Completed_hrs,GPA,Is_pass_web2,Is_pass_pr_mang")] sp_student sp_student)
        {
            sp_student.Name = HttpContext.Session.GetString("stname");

            _context.Add(sp_student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: sp_student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sp_student == null)
            {
                return NotFound();
            }

            var sp_student = await _context.sp_student.FindAsync(id);
            if (sp_student == null)
            {
                return NotFound();
            }
            return View(sp_student);
        }

        // POST: sp_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Email,Phone,Completed_hrs,GPA,Is_pass_web2,Is_pass_pr_mang")] sp_student sp_student)
        {
            if (id != sp_student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sp_studentExists(sp_student.Id))
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
            return View(sp_student);
        }

        // GET: sp_student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sp_student == null)
            {
                return NotFound();
            }

            var sp_student = await _context.sp_student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_student == null)
            {
                return NotFound();
            }

            return View(sp_student);
        }

        // POST: sp_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_student == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_student'  is null.");
            }
            var sp_student = await _context.sp_student.FindAsync(id);
            if (sp_student != null)
            {
                _context.sp_student.Remove(sp_student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_studentExists(int id)
        {
          return (_context.sp_student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
