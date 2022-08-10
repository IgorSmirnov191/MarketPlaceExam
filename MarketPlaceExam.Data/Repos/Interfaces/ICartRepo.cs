using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ICartRepo
    {
        Task AddCart(Cart cart);
        Task DeleteCart(int id);
        Task<Cart> GetCart(int id);
        Task<Cart> GetActiveCart(string userid);
        Task<IEnumerable<Cart>> GetCarts();
        Task UpdateCart(Cart cart);
        bool IsCartsEmpty();
    }
}