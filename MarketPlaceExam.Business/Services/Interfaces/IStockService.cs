using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IStockService
    {
        Task AddStock(StockModel stock);
        Task DeleteStock(int id);
        Task<StockModel> GetStock(int id);
        Task UpdateStock(StockModel stock);
        bool IsStocksEmpty();
    }
}