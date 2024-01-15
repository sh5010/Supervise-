using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Supervise_.Models;
using System.Diagnostics;

namespace Supervise_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }

        [HttpPost, ActionName("login")]
        public async Task<IActionResult> login(string na, string pa)
        {
            var builder = WebApplication.CreateBuilder();
            string conStr = builder.Configuration.GetConnectionString("Supervise+Context");
            SqlConnection conn1 = new SqlConnection(conStr);
            string sql;
            sql = "SELECT * FROM User where name ='" + na + "' and  pass ='" + pa + "' ";
            SqlCommand comm = new SqlCommand(sql, conn1);
            conn1.Open();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                string id = Convert.ToString((int)reader["Id"]);
                string na1 = (string)reader["name"];
                string ro = (string)reader["role"];
                HttpContext.Session.SetString("userid", id);
                HttpContext.Session.SetString("Name", na1);
                HttpContext.Session.SetString("Role", ro);
                reader.Close();
                conn1.Close();
                if (ro == "Student")
                {
                    return RedirectToAction("student_home","Home");
                }
                else if (ro == "facultys")
                {
                    return RedirectToAction("facultys_home","Home");
                }
                else if (ro == "graduation_project_committee")
                {
                    return RedirectToAction("graduation_project_committee","Home");
                }
            }
            else
            {
                ViewData["Message"] = "wrong user name password";
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}