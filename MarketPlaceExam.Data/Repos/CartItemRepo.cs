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
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            return await _context
                .CartItems
                .Include(x => x.Cart)
                .Include(x => x.Product).ThenInclude(y=>y.Picture)
                .ToListAsync();
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
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCartItem(int id)
        {

            int result = 0;
            var cartitem = await _context
                .CartItems
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if(cartitem != null)
            {
                _context.Remove(cartitem);
               result =  await _context.SaveChangesAsync();

            }

            return result > 0;
        }
        
        public bool IsCartItemsEmpty() 
        { 
            return _context.CartItems.Any();
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsByCart(int cartid)
        {
            return await _context
               .CartItems
               .Include(x => x.Cart)
               .Include(x => x.Product).ThenInclude(y=>y.Picture)
               .Where(x=> x.CartId == cartid)
               .ToListAsync();
        }

        public async Task<bool> UpdateQuantityCartItemFromCartByProductId(int cartid, int productId, int quantity)
        {
            int  result = 0;
            var cartitem = await _context
                .CartItems
                .Where(x => x.CartId == cartid)
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();
            if(cartitem != null)
            { cartitem.Quantity = cartitem.Quantity + quantity;
                _context.CartItems.Update(cartitem);
               result = await _context.SaveChangesAsync();

            }
           return result > 0;

        }

        public async Task<bool> UpdateQuantityCartItemById(int itemId, int quantity)
        {
            int result = 0;
            var cartitem = await _context
                .CartItems
                .Where(x => x.Id == itemId)
                .FirstOrDefaultAsync();
            if (cartitem != null)
            {
                cartitem.Quantity = cartitem.Quantity + quantity;
                if(cartitem.Quantity != 0)
                {
                    _context.CartItems.Update(cartitem);
                    result = await _context.SaveChangesAsync();
                }
             }
            return result > 0;
        }
    }
}
