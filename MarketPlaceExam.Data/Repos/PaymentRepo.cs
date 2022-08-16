using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MarketPlaceExam.Data.Repos
{
    public class PaymentRepo : IPaymentRepo
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;


        public PaymentRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<int> AddPayment(Payment payment)
        {
           int id = 0;
           if (payment != null)
            {
             await _context.Payments.AddAsync(payment); 
             await _context.SaveChangesAsync();
             await _context.Entry(payment).GetDatabaseValuesAsync();
            id = payment.Id;
            
              
            }
                return id;

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

        public IQueryable<TModel> GetAllPaymentsByUserId<TModel>(string userId)
        {
            var payments = _context
                .Payments
                .Where(x => x.UserId == userId);
             var result =payments.ProjectTo<TModel>(_mapper.ConfigurationProvider);

            return result;
        }

    }
}
