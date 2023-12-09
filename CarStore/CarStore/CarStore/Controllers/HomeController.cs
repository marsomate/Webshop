using CarStore.DAL;
using CarStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CarStoreDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger,CarStoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Checkout()
        {
            // Add logic for the checkout process here
            // For example, you might want to display a form for user information and payment options.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}