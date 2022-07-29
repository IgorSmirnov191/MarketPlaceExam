using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ICartRepo
    {
        Task AddCart(Cart cart);
        Task DeleteCart(int id);
        Task<Cart> GetCart(int id);
        Task<IEnumerable<Cart>> GetCarts();
        Task UpdateCart(Cart cart);
    }
}