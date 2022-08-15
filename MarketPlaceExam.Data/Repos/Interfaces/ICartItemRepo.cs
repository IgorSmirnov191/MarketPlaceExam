using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ICartItemRepo
    {
        Task AddCartItem(CartItem cartitem);
        Task<bool> DeleteCartItem(int id);
        Task<CartItem> GetCartItem(int id);
        Task<IEnumerable<CartItem>> GetCartItems();
        Task<IEnumerable<CartItem>> GetAllCartItemsByCart(int cartid);
        Task UpdateCartItem(CartItem cartitem);
        bool IsCartItemsEmpty();
        Task<bool> UpdateQuantityCartItemFromCartByProductId(int cartid, int productId, int quantity);
        Task<bool> UpdateQuantityCartItemById(int itemId, int quantity);
    }
}