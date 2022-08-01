using AutoMapper;
using MarketPlaceExam.Data.Entities;
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
    public class CartRepo : ICartRepo
    {
        private ApplicationDbContext _context;

        public CartRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCart(Cart cart)
        {
            if(cart != null)
            {
                 await _context.Carts.AddAsync(cart);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Cart>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetCart(int id)
        {
            return await _context.Carts.FindAsync(id);
        }

        public async Task UpdateCart(Cart cart)
        {
            if (cart != null)
            {
                _context.Carts.Update(cart);
                _context.SaveChanges();
            }
        }

        public async Task DeleteCart(int id)
        {
            var cartlocal = await _context.Carts.FindAsync(id);
            if (cartlocal != null)
            {
                _context.Carts.Remove(cartlocal);
                _context.SaveChanges();
            }
        }
    }
}
