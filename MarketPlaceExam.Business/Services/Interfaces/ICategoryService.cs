using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryModel category);
        Task<CategoryModel> GetCategory(int id);
        Task UpdateCategory(CategoryModel category);
        Task DeleteCategory(int id);
        bool IsCategoriesEmpty();
    }
}