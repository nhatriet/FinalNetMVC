using Microsoft.AspNetCore.Mvc;

namespace EuphoriaShop.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
