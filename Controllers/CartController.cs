using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Euphoria.Helpers;
using Microsoft.AspNetCore.Http;

namespace EuphoriaShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingContext _shoppingContext;
        public CartController(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        // lấy data trong giỏ hàng
        // session lưu 1 mãng các cartitem

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        public IActionResult Cart()

        {

            return View(Carts);
        }

        public IActionResult AddToCart(int Id)
        {
            var MyCart = Carts;
            var item = MyCart.SingleOrDefault(p => p.ProductId == Id);

            if (item == null) // chưa có 
            {
                var Product = _shoppingContext.Products.SingleOrDefault(p => p.ProductId == Id);
                item = new CartItem
                {
                    ProductId = Id,
                    Name = Product.ProductName,
                    Gia = Product.PricePreview,
                    img = Product.ProductImgPreview,
                    soluong = 1

                };
                MyCart.Add(item);
            }
            else
            {
                item.soluong++;
            }
            HttpContext.Session.Set("GioHang", MyCart);
            return RedirectToAction("Cart");
        }
    }
}