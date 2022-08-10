using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ICategoryRepo
    {
        Task<bool> AddCategory(Category category);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> GetCategoryByName(string name);
        Task UpdateCategory(Category category);
        Task Edit(int id, string name, string description);
        bool IsCategoriesEmpty();
    }
}