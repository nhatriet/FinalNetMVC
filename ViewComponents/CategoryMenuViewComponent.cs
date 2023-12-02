using EuphoriaShop.Models;
using EuphoriaShop.Repository;
using Microsoft.AspNetCore.Mvc;
namespace EuphoriaShop.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryRepo _category;
        public CategoryMenuViewComponent(ICategoryRepo categoryRepo)
        {
            _category = categoryRepo;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _category.GetAllCategories().OrderBy(x => x.CategoryName);
            return View(loaisp);
        }
    }
}
