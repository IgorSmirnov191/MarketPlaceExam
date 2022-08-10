using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task AddUser(User user);
        Task DeleteUser(string id);
        Task<User> GetUser(string id);
        Task<IEnumerable<User>> GetUsers();
        Task UpdateUser(User user);
        Task<User> GetUserByUsername(string username);
        bool IsUsersEmpty();
    }
}