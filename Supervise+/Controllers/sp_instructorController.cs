﻿using System;
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
    public class sp_instructorController : Controller
    {
        private readonly Supervise_Context _context;

        public sp_instructorController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_instructor
        public async Task<IActionResult> Index()
        {
            return _context.sp_instructor != null ?
                        View(await _context.sp_instructor.ToListAsync()) :
                        Problem("Entity set 'Supervise_Context.sp_instructor'  is null.");
        }

        // GET: sp_instructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_instructor == null)
            {
                return NotFound();
            }

            var sp_instructor = await _context.sp_instructor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_instructor == null)
            {
                return NotFound();
            }

            return View(sp_instructor);
        }

        // GET: sp_instructor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gender,Email,Phone_Number,Year,Group_Count,Background,interests,rank")] sp_instructor sp_instructor)
        {
            if (sp_instructor.Background == null) sp_instructor.Background = String.Empty;
            if (sp_instructor.interests == null) sp_instructor.interests = String.Empty;

            _context.Add(sp_instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: sp_instructor/Edit/5
        public async Task<IActionResult> Edit()
        {
            string na = (HttpContext.Session.GetString("Name"));


            var sp_instructor = await _context.sp_instructor.Where(m => m.Name == na).FirstOrDefaultAsync();
            if (sp_instructor == null)
            {
                return NotFound();
            }
            if (sp_instructor.Background == null) sp_instructor.Background = String.Empty;
            if (sp_instructor.interests == null) sp_instructor.interests = String.Empty;

            return View(sp_instructor);
        }

        // POST: sp_instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Email,Phone_Number,Year,Group_Count,Background,interests,rank")] sp_instructor sp_instructor)
        {

            if (sp_instructor.Background == null) sp_instructor.Background = string.Empty;
            if (sp_instructor.interests == null) sp_instructor.interests = string.Empty;


            _context.Update(sp_instructor);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    

        // GET: sp_instructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sp_instructor == null)
            {
                return NotFound();
            }

            var sp_instructor = await _context.sp_instructor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sp_instructor == null)
            {
                return NotFound();
            }

            return View(sp_instructor);
        }

        // POST: sp_instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_instructor == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_instructor'  is null.");
            }
            var sp_instructor = await _context.sp_instructor.FindAsync(id);
            if (sp_instructor != null)
            {
                _context.sp_instructor.Remove(sp_instructor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_instructorExists(int id)
        {
          return (_context.sp_instructor?.Any(e => e.Id == id)).GetValueOrDefault();
        }

   
    }
}
