using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services
{
    public interface ICategoryService
    {
        Task AddCategory(CategoryModel category);
        Task<CategoryModel> GetCategory(int id);
    }
}