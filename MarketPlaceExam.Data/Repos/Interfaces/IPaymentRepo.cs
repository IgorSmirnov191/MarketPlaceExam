using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IPaymentRepo
    {
        Task AddPayment(Payment payment);
        Task DeletePayment(int id);
        Task<Payment> GetPayment(int id);
        Task<IEnumerable<Payment>> GetPayments();
        Task UpdatePayment(Payment payment);
    }
}