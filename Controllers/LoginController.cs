using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311.Data;
using PROG7311.Models;

namespace PROG7311.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        public IActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.email == username && e.password == password);
            if (employee != null)
            {
                // Save the employeeID in the session
                HttpContext.Session.SetInt32("UserID", employee.employeeID);

                // Assign admin role in the session
                HttpContext.Session.SetString("UserRole", "Admin");

                // Redirect to the admin dashboard or home page
                return RedirectToAction("Index", "Home");
            }

            var farmer = _context.Farmers.FirstOrDefault(f => f.email == username && f.password == password);
            if (farmer != null)
            {
                // Save the farmerID in the session
                HttpContext.Session.SetInt32("UserID", farmer.farmerID);

                // Assign user role in the session
                HttpContext.Session.SetString("UserRole", "User");

                // Redirect to the user dashboard or home page
                return RedirectToAction("Index", "Home");
            }

            // Step 3: If no match is found, show an error message
            ViewBag.ErrorMessage = "Invalid email or password.";
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Register(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                // Add the farmer to the database
                _context.Farmers.Add(farmer);
                _context.SaveChanges();

                // Redirect to the login page after successful registration
                return RedirectToAction("Login");
            }

            // If the model is invalid, return the same view with validation errors
            return View("~/Views/Home/Register.cshtml", farmer);
        }
    }
}
