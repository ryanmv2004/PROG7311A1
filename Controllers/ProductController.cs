using Microsoft.AspNetCore.Mvc;
using PROG7311.Data;
using PROG7311.Models;

namespace PROG7311.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("~/Views/Home/addProduct.cshtml");
        }

        [HttpPost]
        public IActionResult Add(string productName, string description, string category)
        {
            // gets the farmer from the session
            var farmerID = HttpContext.Session.GetInt32("UserID"); //in this case the userid = the farmers ID as the farmer is the user that can only add products

            if (farmerID == null)
            {
              
                return RedirectToAction("Login", "Login");
            }

            //creates a product object
            var product = new Product
            {
                productName = productName,
                productDescription = description,
                productCategory = category,
                dateAdded = DateOnly.FromDateTime(DateTime.Now),
                farmerID = farmerID.Value //uses the farmerID from the session
            };

            // Add the product to the database
            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
