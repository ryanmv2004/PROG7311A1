using Microsoft.AspNetCore.Mvc;
using PROG7311.Data;
using PROG7311.Models;
using System.Diagnostics;

namespace PROG7311.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult addProduct()
        {
            //gets the user role from the session and if they are not an admin , redirects them to the home page
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "User")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Register()
        {
            //gets the user role from the session and if they are an admin, allows them to create a farmer
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Display()
        {
            //gets the user role from the 
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "Admin" || userRole == "User")
            {
                return RedirectToAction("Display", "Display");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult NotAuthorized()
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
