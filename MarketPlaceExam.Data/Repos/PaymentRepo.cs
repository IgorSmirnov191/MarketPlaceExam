using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

namespace MarketPlaceExam.Data.Repos
{
    public class PaymentRepo : IPaymentRepo
    {
        private ApplicationDbContext _context;


        public PaymentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task AddPayment(Payment payment)
        {
            if (payment != null)
            {
                await _context.Payments.AddAsync(payment);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _context
                .Payments
                .Include( x => x.Carts)
                .Include( x=> x.User)
                .ToListAsync();
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task UpdatePayment(Payment payment)
        {
            if (payment != null)
            {
                _context.Payments.Update(payment);
                _context.SaveChanges();
            }

        }

        public async Task DeletePayment(int id)
        {
            Payment? paymentlocal = await _context.Payments.FindAsync(id);
            if (paymentlocal != null)
            {
                _context.Payments.Remove(paymentlocal);
                _context.SaveChanges();
            }
        }
    }
}
