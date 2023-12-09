using CarStore.DAL;
using CarStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    // This class represents the controller responsible for managing the shopping cart functionality.
    public class CartController : Controller
    {
        private CarStoreDbContext _dbContext;

        // Constructor to initialize the controller with a CarStoreDbContext instance.
        public CartController(CarStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Action method to display the contents of the shopping cart.
        public IActionResult Index()
        {
            // Retrieve the shopping cart items from the session.
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            // Set ViewBag properties for the cart items and total cost.
            ViewBag.Cart = cart;
            ViewBag.Total = cart?.Sum(item => item.Product.Price * item.Quantity) ?? 0;

            // Render the view that displays the shopping cart.
            return View();
        }

        // Action method to add a product to the shopping cart.
        [Route("buy/{id}")]
        public IActionResult Buy(long id)
        {
            // Retrieve the current cart items from the session.
            List<Item>? cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            // If the cart is empty, create a new list with the selected product.
            if (cart == null)
            {
                cart = new List<Item>()
                {
                    new Item { Product = _dbContext.Cars.Find(id), Quantity = 1 }
                };
            }
            else
            {
                // Check if the product is already in the cart.
                int index = IsExist(id);

                // If it exists, increment the quantity; otherwise, add a new item to the cart.
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _dbContext.Cars.Find(id), Quantity = 1 });
                }
            }

            // Update the session with the modified cart.
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            // Redirect to the cart index page.
            return RedirectToAction("Index");
        }

        // Action method to remove a product from the shopping cart.
        [Route("remove/{id}")]
        public IActionResult Remove(long id)
        {
            // Retrieve the current cart items from the session.
            List<Item>? cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            // Find the index of the item to be removed.
            int index = IsExist(id);

            // If the item exists in the cart, remove it and update the session.
            if (index != -1)
            {
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            // Redirect to the cart index page.
            return RedirectToAction("Index");
        }

        // Helper method to check if a product already exists in the cart.
        private int IsExist(long id)
        {
            List<Item>? cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            // Iterate through the cart to find the index of the item with the specified product ID.
            int i = 0;
            while (i < cart.Count && cart[i].Product.CarID != id)
            {
                i++;
            }

            // Return the index if the item is found, otherwise return -1.
            return i < cart.Count ? i : -1;
        }
    }
}
