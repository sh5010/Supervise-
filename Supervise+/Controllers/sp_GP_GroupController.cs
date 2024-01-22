﻿using System;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_GP_Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Supervisor_id,Supervisor_Name,sthead_name,Year,Project_idea,Project_scope,Project_title,Project_description,status,Registration_code")] sp_GP_Group sp_GP_Group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sp_GP_Group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sp_GP_Group);
        }

        // GET: sp_GP_Group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sp_GP_Group == null)
            {
                return NotFound();
            }

            var sp_GP_Group = await _context.sp_GP_Group.FindAsync(id);
            if (sp_GP_Group == null)
            {
                return NotFound();
            }
            return View(sp_GP_Group);
        }

        // POST: sp_GP_Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Supervisor_id,Supervisor_Name,sthead_name,Year,Project_idea,Project_scope,Project_title,Project_description,status,Registration_code")] sp_GP_Group sp_GP_Group)
        {
            if (id != sp_GP_Group.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_GP_Group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sp_GP_GroupExists(sp_GP_Group.id))
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
            return View(sp_GP_Group);
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