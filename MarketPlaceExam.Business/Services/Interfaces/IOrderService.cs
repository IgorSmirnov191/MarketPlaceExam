using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(OrderModel category);
        Task DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task UpdateOrder(OrderModel order);
    }
}