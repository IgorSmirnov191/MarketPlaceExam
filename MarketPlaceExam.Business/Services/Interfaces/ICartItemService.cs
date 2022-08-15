using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddCartItem(CartItemModel cartitem);
        Task<bool> DeleteCartItem(int id);
        Task<CartItemModel> GetCartItem(int id);
        Task<IEnumerable<CartItemModel>> GetAllCartItemsByCart(int cartid);
        Task<bool> UpdateQuantityCartItemFromCartByProductId(int cartid, int productId, int quantity);
        Task<bool> UpdateQuantityCartItemById(int itemId, int quantity);
        Task UpdateCartItem(CartItemModel cartitem);
        bool IsCartItemsEmpty();
    }
}