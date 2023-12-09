using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EuphoriaShop.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Customer()
        {
            Customer userProfile = new Customer
            {
                LastName = "Ngoc Nguyen",
                FirstName = "Tran",
                Email = "john.doe@example.com"
            };

            return View("Customer", userProfile);
        }
    }
}
