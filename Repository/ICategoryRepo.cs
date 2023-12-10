using EuphoriaShop.Models;
namespace EuphoriaShop.Repository
{
    public interface ICategoryRepo
    {
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(Category categoryId);
        Category GetCategory(String categoryId);

        IEnumerable<Category> GetAllCategories();
    }
}
