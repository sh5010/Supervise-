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
        public IActionResult FacultyHome()
        {
            return View();
        }

        public IActionResult GPMemberHome()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
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