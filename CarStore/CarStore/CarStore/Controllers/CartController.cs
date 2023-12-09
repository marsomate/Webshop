using CarStore.DAL;
using CarStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    public class CartController : Controller
    {
        private CarStoreDbContext _dbContext;

        public CartController(CarStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.Cart = cart;
            ViewBag.Total = cart?.Sum(item => item.Product.Price * item.Quantity) ?? 0;
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(long id)
        {
            List<Item>? cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>()
                {
                    new Item{Product=_dbContext.Cars.Find(id),Quantity=1 }
                };
            }
            else
            {
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _dbContext.Cars.Find(id), Quantity = 1 });
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(long id)
        {
            List<Item>? cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            if (index != -1)
            {
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        

        private int IsExist(long id)
        {
            List<Item>? cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int i = 0;
            while (i < cart.Count && cart[i].Product.CarID != id)
            {
                i++;
            }
            return i < cart.Count ? i : -1;
        }
    }
}
