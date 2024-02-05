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
    public class sp_gp_ideasController : Controller
    {
        private readonly Supervise_Context _context;

        public sp_gp_ideasController(Supervise_Context context)
        {
            _context = context;
        }

        // GET: sp_gp_ideas
        public async Task<IActionResult> Index()
        {
            string ro = (HttpContext.Session.GetString("Role"));
            ViewData["Role"] = ro;
            return _context.sp_gp_ideas != null ? 
                          View(await _context.sp_gp_ideas.ToListAsync()) :
                          Problem("Entity set 'Supervise_Context.sp_gp_ideas'  is null.");
        }

        // GET: sp_gp_ideas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sp_gp_ideas == null)
            {
                return NotFound();
            }

            var sp_gp_ideas = await _context.sp_gp_ideas
                .FirstOrDefaultAsync(m => m.id == id);
            if (sp_gp_ideas == null)
            {
                return NotFound();
            }

            return View(sp_gp_ideas);
        }

        // GET: sp_gp_ideas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sp_gp_ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,InstructorName,Idea,Description")] sp_gp_ideas sp_gp_ideas)
        {
            string na = (HttpContext.Session.GetString("Name"));
            sp_gp_ideas.InstructorName = na;
            _context.Add(sp_gp_ideas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // GET: sp_gp_ideas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string na = (HttpContext.Session.GetString("Name"));
            
            

            var sp_gp_ideas = await _context.sp_gp_ideas.FindAsync(id);
            if (na != sp_gp_ideas.InstructorName)
            {
                ViewData["Message"] = "You cannot edit other instructor idea";
                return View();

            }

                return View(sp_gp_ideas);
        }

        // POST: sp_gp_ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,InstructorName,Idea,Description")] sp_gp_ideas sp_gp_ideas)
        {
            if (id != sp_gp_ideas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sp_gp_ideas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sp_gp_ideasExists(sp_gp_ideas.id))
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
            return View(sp_gp_ideas);
        }

        // GET: sp_gp_ideas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string na = (HttpContext.Session.GetString("Name"));



            var sp_gp_ideas = await _context.sp_gp_ideas.FindAsync(id);
            if (na != sp_gp_ideas.InstructorName)
            {
                ViewData["Message"] = "You cannot Delete other instructor idea";
                return View();

            }

            return View(sp_gp_ideas);
        }

        // POST: sp_gp_ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sp_gp_ideas == null)
            {
                return Problem("Entity set 'Supervise_Context.sp_gp_ideas'  is null.");
            }
            var sp_gp_ideas = await _context.sp_gp_ideas.FindAsync(id);
            if (sp_gp_ideas != null)
            {
                _context.sp_gp_ideas.Remove(sp_gp_ideas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sp_gp_ideasExists(int id)
        {
          return (_context.sp_gp_ideas?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
