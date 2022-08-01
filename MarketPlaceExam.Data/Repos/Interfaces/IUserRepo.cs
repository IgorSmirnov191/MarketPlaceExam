using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task UpdateUser(User user);
    }
}