using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserModel user);
        Task DeleteUser(int id);
        Task<UserModel> GetUser(int id);
        Task UpdateUser(UserModel user);
        bool IsUsersEmpty();
    }
}