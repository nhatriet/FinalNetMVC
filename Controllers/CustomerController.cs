using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShoppingContext _context;

        public CustomerController(ShoppingContext context)
        {
            _context = context;
        }

        ShoppingContext db = new ShoppingContext();

        public IActionResult Customer()
        {
            var loggedIn = db.Accounts.FirstOrDefault(x => x.Username == HttpContext.Session.GetString("Username"));
            var Khachhang = db.Customers.FirstOrDefault(x => x.AccountId == loggedIn.AccountId);
            Console.WriteLine("Function call" + loggedIn.Username);
            var KH = db.Customers.Where(x => x.CustomerId == loggedIn.AccountId).ToList();
            ViewBag.KH = KH;
            return View(Khachhang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(Customer customer)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (ModelState.IsValid)
            {
                try
                {
                    // Lấy thông tin khách hàng từ cơ sở dữ liệu
                    var existingCustomer = db.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                    // Nếu không tìm thấy khách hàng, trả về trang 404 hoặc xử lý theo nhu cầu của bạn
                    if (existingCustomer == null)
                    {
                        return NotFound();
                    }

                    // Cập nhật thông tin của khách hàng từ dữ liệu gửi từ form
                    existingCustomer.FirstName = customer.FirstName;
                    existingCustomer.LastName = customer.LastName;
                    existingCustomer.Birthday = customer.Birthday;
                    existingCustomer.Email = customer.Email;
                    existingCustomer.Phone = customer.Phone;
                    existingCustomer.Address = customer.Address;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    // Chuyển hướng đến action hiển thị thông tin khách hàng sau khi cập nhật
                    return RedirectToAction(nameof(Customer));
                }
                catch (Exception)
                {
                    // Xử lý lỗi nếu có
                    return View("Error");
                }
            }

            // Nếu dữ liệu không hợp lệ, hiển thị lại form với các thông báo lỗi
            return View("Customer", customer);
        }
    }
}

