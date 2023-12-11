using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace EuphoriaShop.Controllers
{
    public class AccessController : Controller
    {
        ShoppingContext db = new ShoppingContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }           
        }
        [HttpPost]
        public IActionResult Login(Account account)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var a = db.Accounts.Where(x => x.Username.Equals(account.Username) && x.Password.Equals
                (account.Password)).FirstOrDefault();
                if ( a != null)
                {
                    HttpContext.Session.SetString("Username", a.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Home", "Index");
        }
    }
}
