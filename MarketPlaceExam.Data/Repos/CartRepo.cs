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
            // return await _context.Carts.FindAsync(id);
            return await _context
                     .Carts
                     .Include(x => x.CartItems)
                     .ThenInclude(y => y.Product).ThenInclude(z => z.Picture)
                     .SingleOrDefaultAsync(x => x.Id == id);

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

        public async Task<bool> UpdatePaymentActiveCart(Payment payment)
        {
            int result = 0;
           
            if (String.IsNullOrEmpty(payment.UserId))
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();
                await _context.Entry(payment).GetDatabaseValuesAsync();
               
                Cart cartnew = new Cart();
                cartnew.PaymentId = payment.Id;
                await _context.Carts.AddAsync(cartnew);
                await _context.SaveChangesAsync();
                await _context.Entry(payment).GetDatabaseValuesAsync();

                var cartitems = await _context
                    .CartItems
                    .Where(x => x.CartId == 1).ToListAsync();
                foreach(CartItem cartItem in cartitems)
                {
                   await _context.CartItems.AddAsync( new CartItem { CartId = cartnew.Id, ProductId = cartItem.ProductId, Quantity = cartItem.Quantity});
                   _context.CartItems.Remove(cartItem);
                }

                result = await _context.SaveChangesAsync();
            }
            else
            {
                var cart = await _context
                    .Carts
                    .Where(x => x.PaymentId == null)
                    .SingleOrDefaultAsync(x => x.UserId == payment.UserId);
                if (cart != null)
                {
                    await _context.Payments.AddAsync(payment);
                    await _context.SaveChangesAsync();
                    await _context.Entry(payment).GetDatabaseValuesAsync();
                    cart.PaymentId = payment.Id;
                    _context.Carts.Update(cart);
                    Cart cartnew = new Cart();
                    cartnew.UserId = payment.UserId;
                    await _context.Carts.AddAsync(cartnew);
                    result = await _context.SaveChangesAsync();
                }

            }
            
            
            return result > 0;
        }
    }
}
