using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ICartService
    {
        Task AddCart(CartModel cart);
        Task DeleteCart(int id);
        Task<CartModel> GetCart(int id);
        Task UpdateCart(CartModel cart);
        Task<CartModel> GetActiveCart(string userid);
        bool IsCartsEmpty();
        Task ClearCart(int id);
    }
}