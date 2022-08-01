using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Services
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryModel category);
        Task<CategoryModel> GetCategory(int id);
        Task UpdateCategory(CategoryModel category);
        Task DeleteCategory(int id);
    }
}