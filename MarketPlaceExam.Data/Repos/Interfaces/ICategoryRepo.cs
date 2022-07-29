using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ICategoryRepo
    {
        Task AddCategory(Category category);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task UpdateCategory(Category category);
    }
}