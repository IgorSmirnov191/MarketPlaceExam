using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

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
            if (cart != null)
            {
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cart>> GetCarts()
        {
            return await _context
                .Carts
                .Include(x => x.User)
                .Include(x => x.Payment)
                .ToListAsync();
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
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCart(int id)
        {
            Cart? cartlocal = await _context.Carts.FindAsync(id);
            if (cartlocal != null)
            {
                _context.Carts.Remove(cartlocal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetActiveCart(string userid)
        {
            return await _context
                    .Carts
                    .Include(x => x.CartItems)
                    .ThenInclude(y => y.Product).ThenInclude(z=>z.Picture)
                    .Where(x => x.PaymentId == null)
                    .SingleOrDefaultAsync(x => x.UserId == userid);

        }
        public bool IsCartsEmpty()
        {
            return _context.Carts.Any();
        }

        public async Task ClearCart(int id)
        {
            foreach(var cartitem in _context.CartItems.Where(e=>e.CartId == id))
            {
               _context.CartItems.Remove(cartitem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
