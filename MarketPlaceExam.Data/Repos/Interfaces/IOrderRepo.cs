using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IOrderRepo
    {
        Task AddOrder(Order orderitem);
        Task DeleteOrder(int id);
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task UpdateOrder(Order orderitem);
    }
}