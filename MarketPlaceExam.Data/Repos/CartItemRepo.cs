using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

namespace MarketPlaceExam.Data.Repos
{
    public class CartItemRepo : ICartItemRepo
    {
        private ApplicationDbContext _context;

        public CartItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCartItem(CartItem cartitem)
        {
            if (cartitem != null)
            {
                await _context.CartItems.AddAsync(cartitem);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }

        public async Task<CartItem> GetCartItem(int id)
        {
            return await _context.CartItems.FindAsync(id);
        }

        public async Task UpdateCartItem(CartItem cartitem)
        {
            if (cartitem != null)
            {
                _context.CartItems.Update(cartitem);
                _context.SaveChanges();
            }
        }

        public async Task DeleteCartItem(int id)
        {
            var cartitemlocal = await _context.CartItems.FindAsync(id);
            if (cartitemlocal != null)
            {
                _context.CartItems.Remove(cartitemlocal);
                _context.SaveChanges();
            }
        }
        public bool IsCartItemsEmpty() 
        { 
            return _context.CartItems.Any();
        }
    }
}
