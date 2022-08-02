using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddCartItem(CartItemModel cartitem);
        Task DeleteCartItem(int id);
        Task<CartItemModel> GetCategory(int id);
        Task UpdateCartItem(CartItemModel cartitem);
    }
}