using MarketPlaceExam.Business.Model;
using Microsoft.AspNetCore.Identity;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserModel user);
        Task DeleteUser(string id);
        Task<UserModel> GetUser(string id);
        Task UpdateUser(UserModel user);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<IEnumerable<string>> GetUserRoles(string id);
        Task<IdentityResult> ChangePassword(string id, string password);
        Task<UserModel> GetUserByUsername(string username);
        bool IsUsersEmpty();
    }
}