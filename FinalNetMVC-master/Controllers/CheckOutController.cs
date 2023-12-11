using Microsoft.AspNetCore.Mvc;

namespace EuphoriaShop.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
