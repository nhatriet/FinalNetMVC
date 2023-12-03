using Microsoft.AspNetCore.Mvc;

namespace EuphoriaShop.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
   

}
