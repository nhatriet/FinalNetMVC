using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EuphoriaShop.Controllers
{
    public class EventController : Controller
    {
        private readonly ShoppingContext _context;

        public EventController(ShoppingContext context)
        {
            _context = context;
        }

        ShoppingContext db = new ShoppingContext();
        public IActionResult Event(int maSp)
        {
            /*var sanPham = db.ProductSizes.Where(x => x.ProductId == maSp).ToList();

            return View(sanPham);*/
            var listProduct = db.Products.ToList();

            return View(listProduct);
        }
    }
}
