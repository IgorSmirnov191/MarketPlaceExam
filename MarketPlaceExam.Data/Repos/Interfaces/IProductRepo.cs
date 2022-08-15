using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IProductRepo
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsBySupplierId(int supplierId);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetProductsByNameAndCategory(string name, string category);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<Product> GetProduct(int id);
        Task<bool> UpdateProduct(Product product);
        bool IsProductsEmpty();
    }
}