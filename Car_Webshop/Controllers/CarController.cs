using Microsoft.AspNetCore.Mvc;
using Car_Webshop.Models;

namespace Car_Webshop.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index(int n = 0)
        {
            return View();
        }
        
        [ActionName("Select")]

        public IActionResult Select(int n = 0)
        {
            List<Car> cars = Cars.List();
            
            ViewBag.Manufacturer = cars[n].Manufacturer;
            ViewBag.Type = cars[n].Type;
            ViewBag.Model = cars[n].Model;
            ViewBag.RegistrationDate = cars[n].RegistrationDate;
            ViewBag.ChassisNumber = cars[n].ChassisNumber;
            ViewBag.Specification = cars[n].Specification;
            ViewBag.Description = cars[n].Description;
            ViewBag.Issues = cars[n].Issues;
            
            return View();
        }

        [ActionName("Summary")]

        public IActionResult Summary()
        {
            List<Car> cars = Cars.List();
            return View(cars);
        }

        [ActionName("Add")]
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            Cars.List().Add(car);
            return RedirectToAction("Index");
        }


    }
}
