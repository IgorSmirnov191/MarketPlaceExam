using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IStockRepo
    {
        Task AddStock(Stock stock);
        Task DeleteStock(int id);
        Task<Stock> GetStock(int id);
        Task<IEnumerable<Stock>> GetStocks();
        Task UpdateStock(Stock stock);
    }
}