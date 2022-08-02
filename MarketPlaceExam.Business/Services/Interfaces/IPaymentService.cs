using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IPaymentService
    {
        Task AddPayment(PaymentModel payment);
        Task DeletePayment(int id);
        Task<PaymentModel> GetPayment(int id);
        Task UpdatePayment(PaymentModel payment);
    }
}