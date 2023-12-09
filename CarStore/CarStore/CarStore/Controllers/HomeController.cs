using CarStore.DAL;
using CarStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CarStore.Controllers
{
    // This class represents the controller for the home-related actions of the application.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CarStoreDbContext _dbContext;

        // Constructor to initialize the controller with a logger and a CarStoreDbContext instance.
        public HomeController(ILogger<HomeController> logger, CarStoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // Action method to display the home page with a list of cars from the database.
        public IActionResult Index()
        {
            // Retrieve the list of cars from the database and pass it to the view.
            return View(_dbContext.Cars);
        }

        // Action method to display the privacy page.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method to display the checkout page.
        public IActionResult Checkout()
        {
            return View();
        }

        // Action method to handle errors and display the error page.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create an ErrorViewModel with the request ID for error tracking.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
