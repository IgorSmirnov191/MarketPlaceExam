using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductModel product);
        Task DeleteProduct(int id);
        Task<ProductModel> GetProduct(int id);
        Task UpdateProduct(ProductModel product);
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<IEnumerable<ProductModel>> GetProductsBySupplier(int supplierId);
        Task<IEnumerable<ProductModel>> GetProductsByCategory(int categoryId);
        bool IsProductsEmpty();
    }
}