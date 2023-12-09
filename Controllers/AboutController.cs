using Microsoft.AspNetCore.Mvc;

namespace EuphoriaShop.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
