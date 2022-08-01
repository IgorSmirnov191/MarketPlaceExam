using AutoMapper;
using MarketPlace.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _context.Payments.AddAsync(payment);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task UpdatePayment(Payment payment)
        {
            var paymentlocal = await _context.Payments.FindAsync(payment.Id);
            if (paymentlocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, Payment>());
                var mapper = new Mapper(config);
                paymentlocal = mapper.Map<Payment>(payment);
                _context.SaveChanges();

            }
        }

        public async Task DeletePayment(int id)
        {
            var paymentlocal = await _context.Payments.FindAsync(id);
            if (paymentlocal != null)
            {
                _context.Payments.Remove(paymentlocal);
                _context.SaveChanges();
            }
        }
    }
}
