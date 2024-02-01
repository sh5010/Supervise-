using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Supervise_.Models;
using System.Diagnostics;
using System.Net.Mail;

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
        public IActionResult FacultyHome()
        {
            return View();
        }

        public IActionResult GPMemberHome()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Email()
        {
            return View();
        }
        


        [HttpPost, ActionName("Email")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Email(string address, string subject, string body)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("ccse.projects@gmail.com");
            mail.To.Add(address); // receiver email address
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ccse.projects@gmail.com", "fpziukvqekvoqjcx");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            ViewData["Message"] = "Email sent.";
            return View();

        }



        [HttpPost, ActionName("login")]
       
        public async Task<IActionResult> login(string na, string pa)
        {
            var builder = WebApplication.CreateBuilder();
            string conStr = builder.Configuration.GetConnectionString("Supervise_Context");
            SqlConnection conn1 = new SqlConnection(conStr);
            string sql;
            sql = "SELECT * FROM sp_user_account where name ='" + na + "' and  password ='" + pa + "' ";
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
                HttpContext.Session.SetString("Role", ro); ;
                reader.Close();
                conn1.Close();
                if (ro == "student")
                    return RedirectToAction("sthome", "Home");
                else if (ro == "instructor")
                    return RedirectToAction("FacultyHome", "Home");
                else if (ro == "gpcm")
                    return RedirectToAction("GPMemberHome", "Home");
                else
                    return View();
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

        public IActionResult sthome()
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