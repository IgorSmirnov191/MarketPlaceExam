using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(OrderModel order);
        Task DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task UpdateOrder(OrderModel order);
        Task<IEnumerable<OrderModel>> GetAllOrders();
        Task<IEnumerable<OrderModel>> GetMyOrders(string userId);
    }
}