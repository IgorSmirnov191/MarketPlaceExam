using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IStockRepo
    {
        Task<bool> AddStock(Stock stock);
        Task DeleteStock(int id);
        Task<Stock> GetStock(int id);
        Task<Stock> GetStockByProductId(int productid);
        Task<IEnumerable<Stock>> GetStocks();
        Task<bool> UpdateStock(Stock stock);
        bool IsStocksEmpty();
        Task DeleteStockByProductId(int productid);
        Task<bool> AddPicturePath(int productId, string url);
        IQueryable<TModel> GetAllStockProducts<TModel>();
        IQueryable<TModel> GetStockProductByInputAndCategoryName<TModel>(string input, string categoryName);

        IQueryable<TModel> GetStockProductByInput<TModel>(string input);

        IQueryable<TModel> GetStockProductByCategoryName<TModel>(string categoryName);
        IQueryable<TModel> GetStockProductByCategoryId<TModel>(int categoryId);
    }
}