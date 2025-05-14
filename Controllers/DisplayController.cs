using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311.Data;
using PROG7311.ViewModels;

namespace PROG7311.Controllers
{
    public class DisplayController : Controller
    {
        private readonly AppDbContext _context;

        public DisplayController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Display(int? FarmerId, DateTime? DateAdded, string Category)
        {
            //retrieves all the farmers from the database
            var farmers = _context.Farmers.ToList();

            //the structure for the query to the database
            var productsQuery = _context.Products.Include(p => p.farmer).AsQueryable(); //https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager

            //filters by selected farmer by their ID
            if (FarmerId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.farmerID == FarmerId.Value);
            }
            //filters the products by the date created
            if (DateAdded.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.dateAdded == DateOnly.FromDateTime(DateAdded.Value));
            }
            //filters by product catgegories that exist in the database
            if (!string.IsNullOrEmpty(Category))
            {
                productsQuery = productsQuery.Where(p => p.productCategory == Category);
            }

            //executes the query and retrieves the products from the database
            var products = productsQuery.ToList();

            //creates a view model to pass the data to the view
            var viewModel = new DisplayViewModel
            {
                Farmers = farmers,
                Products = products,
                SelectedFarmerId = FarmerId,
                SelectedDate = DateAdded,
                SelectedCategory = Category,
                Categories = _context.Products.Select(p => p.productCategory).Distinct().ToList()
            };

            return View("~/Views/Home/displayFarmers.cshtml", viewModel);
        }

    }
}
