using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IStockService
    {
        Task<bool> AddProductToStock(StockModel stock);
        Task AddCategoryToProduct(int productid, CategoryModel category);
        Task DeleteFromStockById(int stockid);
        Task DeleteFromStockByProductId(int productid);
        Task<StockModel> GetFromStockByStockId(int stockid);
        Task<StockModel> GetFromStockByProductId(int productid);
        Task UpdateStock(StockModel stock);
        Task<bool> AddPicturePath(int productId, string picturePath);
        bool IsStocksEmpty();
        IQueryable<TModel> GetStockProductsByCategoryId<TModel>(int categoryId);
        IQueryable<TModel> GetAllStockProducts<TModel>();
        IQueryable<TModel> GetStockProductByInputAndCategoryName<TModel>(string input, string categoryName);

        IQueryable<TModel> GetStockProductByInput<TModel>(string input);

        IQueryable<TModel> GetStockProductsByCategoryName<TModel>(string categoryName);
    }
}