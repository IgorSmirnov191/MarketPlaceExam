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
    public class OrderRepo : IOrderRepo
    {
        private ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCartItem(Order orderitem)
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
            var orderitemlocal = await _context.Orders.FindAsync(orderitem.Id);
            if (orderitemlocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, Order>());
                var mapper = new Mapper(config);
                orderitemlocal = mapper.Map<Order>(orderitemlocal);
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
