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
            var usr = await _context.sp_user_account.FromSqlRaw("select * from sp_user_account where Role ='instructor' ").ToListAsync();
            return View(usr);
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
            var builder = WebApplication.CreateBuilder();
            string conStr = builder.Configuration.GetConnectionString("Supervise_Context");
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            Boolean flage = false;
            string sql = "select * from sp_user_account  where name = '" + sp_user_account.Name + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            { flage = true; }
            reader.Close();
            conn.Close();
            if (flage == true)
            {
                ViewData["message"] = "name already exists";
                return View();

            }
            else
            {
                
                    HttpContext.Session.SetString("stname", sp_user_account.Name);
                    sp_user_account.Role = "student";
                    _context.Add(sp_user_account);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "sp_student");
                

               
               
            }
            
        }

        public IActionResult CreateInst()
        {
            return View();
        }

        // POST: sp_user_account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInst([Bind("Id,Name,Password,Role")] sp_user_account sp_user_account)
        {
            var builder = WebApplication.CreateBuilder();
            string conStr = builder.Configuration.GetConnectionString("Supervise_Context");
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            Boolean flage = false;
            string sql = "select * from sp_user_account  where name = '" + sp_user_account.Name + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            { flage = true; }
            reader.Close();
            conn.Close();
            if (flage == true)
            {
                ViewData["message"] = "name already exists";
                return View();

            }
            else
            {
                

                
                    sp_user_account.Role = "instructor";
                    _context.Add(sp_user_account);
                    await _context.SaveChangesAsync();

                    sp_instructor instructor = new sp_instructor();
                    instructor.Name = sp_user_account.Name;

                instructor.Background = String.Empty;
                instructor.interests = String.Empty;



                _context.sp_instructor.Add(instructor);
                    await _context.SaveChangesAsync();


                    return RedirectToAction("index", "sp_user_account");







            }

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
