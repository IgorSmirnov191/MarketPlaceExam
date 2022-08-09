using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

namespace MarketPlaceExam.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOrder(Order orderitem)
        {
            if (orderitem != null)
            {
                await _context.Orders.AddAsync(orderitem);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task UpdateOrder(Order orderitem)
        {
            if (orderitem != null)
            {
                _context.Orders.Update(orderitem);
                _context.SaveChanges();
            }

        }

        public async Task DeleteOrder(int id)
        {
            var orderitemlocal = await _context.Orders.FindAsync(id);
            if (orderitemlocal != null)
            {
                _context.Orders.Remove(orderitemlocal);
                _context.SaveChanges();
            }
        }
       
    }
}
