using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddCartItem(CartItemModel cartitem);
        Task DeleteCartItem(int id);
        Task<CartItemModel> GetCartItem(int id);
        Task<IEnumerable<CartItemModel>> GetAllCartItemsByCart(int cartid);
        Task UpdateCartItem(CartItemModel cartitem);
        bool IsCartItemsEmpty();
    }
}