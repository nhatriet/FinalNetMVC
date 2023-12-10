using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace EuphoriaShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShoppingContext _context;

        public HomeController(ShoppingContext context)
        {
            _context = context;
        }

        ShoppingContext db = new ShoppingContext();
/*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index(int ?page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listProduct = db.Products.AsNoTracking().OrderBy(x => x.ProductName);
            PagedList<Product> lst = new PagedList<Product>(listProduct, pageNumber, pageSize);

            return View(listProduct);
        }

        public IActionResult SanPhamTheoLoai(int maloai)
        {
            List<Product> lstsanpham=db.Products.Where
             (x => x.CategoryId == maloai).OrderBy(x => x.ProductName).ToList();
            return View(lstsanpham);
        }
        public IActionResult ChiTietSanPham(int maSp)
        {
            var sanPham = db.Products.SingleOrDefault(x => x.ProductId == maSp);
            var anhSanPham = db.ProductImages.Where(x => x.ProductId == maSp).ToList();
            var SizeSanPham = db.ProductSizes.Where(x => x.ProductId == maSp).ToList();
            List<EuphoriaShop.Models.Size> LSIZE = new List<EuphoriaShop.Models.Size>();
            foreach (var item in SizeSanPham)
            {
                var SizeSP = db.Sizes.FirstOrDefault(c => c.SizeId == item.SizeId);
                if (SizeSP != null)
                {
                    LSIZE.Add(SizeSP);
                }
            }
            ViewBag.size = LSIZE;

            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }
       /* public IActionResult AddComment(int productId, string userName, string content)
        {
            // Tạo một đối tượng Comment mới
            var newComment = new Comment
            {
                ProductId = productId,
                UserName = userName,
                Content = content,
                CreatedAt = DateTime.Now
            };

           *//* // Lưu bình luận vào cơ sở dữ liệu
            ShoppingContext.Comments.Add(newComment);
            ShoppingContext.SaveChanges();*//*

            // Chuyển hướng về trang chi tiết sản phẩm
            return RedirectToAction("ChiTietSanPham");
        }*/
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}