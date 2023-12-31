﻿using EuphoriaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using X.PagedList;

namespace EuphoriaShop.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeAdminController : Controller
    {
        ShoppingContext db = new ShoppingContext();
        [Route("")]
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page, string searchString)
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
        
            var listSanPham = from p in db.Products
                              select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                listSanPham = listSanPham.Where(s => s.ProductName!.Contains(searchString)).OrderBy(s => s.ProductId);
            }
            
            PagedList < Product > list = new PagedList<Product>(listSanPham, pageNumber, pageSize);
            return View(list);
        }
        
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Home");
        }

        //Thêm sản phẩm
        [Route("danhmucsanpham/themsanpham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.ProductId = db.Products.OrderByDescending(u => u.ProductId).FirstOrDefault().ProductId + 1;
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(),"CategoryId", "CategoryName");
            return View();
        }
        [Route("danhmucsanpham/themsanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            } 
            else
            {
                return View(sanPham);
            }
        }

        //Sửa sản phẩm
        [Route("danhmucsanpham/suasanpham")]
        [HttpGet]
        public IActionResult SuaSanPham(int iD)
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            var sanPham = db.Products.Find(iD);
            return View(sanPham);
        }
        [Route("danhmucsanpham/suasanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            else
            {
                return View(sanPham);
            }
        }

        //Xoá sản phẩm
        [Route("danhmucsanpham/xoasanpham")]
        [HttpGet]
        public IActionResult XoaSanPham(int iD)
        {
            TempData["Message"] = "";
            var order = db.ProductOrders.Where(x => x.ProductId == iD).ToList();
            if (order.Count > 0)
            {
                TempData["Message"] = "Sản phẩm đã có đơn hàng. Không thể xoá sản phẩm.";
                return RedirectToAction("DanhMucSanPham");
            }
            db.Remove(db.Products.Find(iD));
            db.SaveChanges();
            TempData["Message"] = "Xoá thành công";
            return RedirectToAction("DanhMucSanPham");
        }
        
        
        [Route("CategoryProduct")]
        public IActionResult CategoryProduct(int? page, string searchString) 
        {
            int pageSize = 5;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listCategory = from c in db.Categories
                              select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                listCategory = listCategory.Where(s => s.CategoryName!.Contains(searchString)).OrderBy(s => s.CategoryId);
            }

            PagedList<Category> list = new PagedList<Category>(listCategory, pageNumber, pageSize);
            return View(list);
            
        }
        
        //Thêm danh mục
        [HttpGet]
        [Route("CategoryProduct/Add")]
        public IActionResult ThemDanhMuc()
        {
            ViewBag.CategoryId = db.Categories.OrderByDescending(u => u.CategoryId).FirstOrDefault().CategoryId + 1;
            return View();
        }
        [Route("CategoryProduct/Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemDanhMuc(Category danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("CategoryProduct");
            }
            else
            {
                return View(danhMuc);
            }
        }

        //Sửa danh mục
        [Route("CategoryProduct/SuaDanhMuc")]
        [HttpGet]
        public IActionResult SuaDanhMuc(int iD)
        {
            var category = db.Categories.Find(iD);
            return View(category);
        }
        [Route("CategoryProduct/SuaDanhMuc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaDanhMuc(Category danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryProduct");
            }
            else
            {
                return View(danhMuc);
            }
        }

        //Xoá danh mục
        [Route("CategoryProduct/XoaDanhMuc")]
        [HttpGet]
        public IActionResult XoaDanhMuc(int iD)
        {

            TempData["Message"] = "";
            var listProduct = db.Products.Where(x => x.CategoryId == iD).ToList();
            if (listProduct.Count() > 0)
            {
                TempData["Message"] = "Bạn cần phải xoá hết tất cả sản phẩm thuộc danh mục " + db.Categories.Find(iD).CategoryName + " này trước.";
                return RedirectToAction("CategoryProduct");
            }
            db.Remove(db.Categories.Find(iD));
            db.SaveChanges();
            TempData["Message"] = "Xoá thành công";
            return RedirectToAction("CategoryProduct");
        }

        //Thống kê
        [Route("ThongKe")]
        public  IActionResult ThongKe()
        {
            List<object> data = new List<object>();

            List<int> totalProduct = db.Statistics.Select(x => x.TotalProduct).ToList();
            List<int> year = db.Statistics.Select(x => x.Year).ToList();
            
            data.Add(totalProduct);
            data.Add(year);

            return View();
        }

        [Route("GetThongKe")]
        [HttpGet]
        public List<object> GetThongKe()
        {
            List<object> data = new List<object>();
            List<int> totalProduct = db.Statistics.Select(x => x.TotalProduct).ToList();
            List<int> year = db.Statistics.Select(x => x.Year).ToList();
            data.Add(year);
            data.Add(totalProduct);
            return data;
        }
    }
}
