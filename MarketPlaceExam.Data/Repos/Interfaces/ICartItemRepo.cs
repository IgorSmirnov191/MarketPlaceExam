using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ICartItemRepo
    {
        Task AddCartItem(CartItem cartitem);
        Task DeleteCartItem(int id);
        Task<CartItem> GetCartItem(int id);
        Task<IEnumerable<CartItem>> GetCartItems();
        Task UpdateCartItem(CartItem cartitem);
    }
}