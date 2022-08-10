using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MarketPlaceExam.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private ApplicationDbContext _context;
        private readonly IMapper mapper;


        public OrderRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task AddOrder(Order orderitem)
        {
            if (orderitem != null)
            {
                await _context.Orders.AddAsync(orderitem);
                _context.SaveChanges();
            }

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
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context
                        .Orders
                        .Include(x =>x.Cart)
                        .Include(x =>x.Payment)
                        .Include(x =>x.User)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetMyOrders(string userId)
        {
            return await _context
                        .Orders
                        .Include(x => x.Cart)
                        .Include(x => x.Payment)
                        .Where(x => x.UserId == userId)
                        .ToListAsync();
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
