using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IProductRepo
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task UpdateProduct(Product product);
    }
}