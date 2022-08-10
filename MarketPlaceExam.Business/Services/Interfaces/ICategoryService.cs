using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryModel category);
        Task UpdateCategory(CategoryModel category);
        Task DeleteCategoryById(int id);
        Task<CategoryModel> GetCategoryById(int id);
        Task<CategoryModel> GetCategoryByName(string name);
        Task<IEnumerable<CategoryModel>> GetAllCategories();
        Task<bool> Create(string name, string desc);
        Task Edit(int id, string name, string desc);
        bool IsCategoriesEmpty();
    }
}