using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Services
{
    public class UserService : IUserService
    {
        // Dependencies
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepo repo, IMapper mapper, UserManager<User> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task AddUser(UserModel user)
        {
            var userEntity = _mapper.Map<UserModel, User>(user);
            await _repo.AddUser(userEntity);
        }

        public async Task<UserModel> GetUser(string id)
        {
            User userEntity = await _repo.GetUser(id);
            var model = _mapper.Map<User, UserModel>(userEntity);
            return model;
        }
        public async Task UpdateUser(UserModel user)
        {
            var userEntity = _mapper.Map<UserModel, User>(user);
            await _repo.UpdateUser(userEntity);
        }

        public async Task DeleteUser(string id)
        {
            await _repo.DeleteUser(id);
        }

        public bool IsUsersEmpty()
        {
            return _repo.IsUsersEmpty();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var userEntity = await _repo.GetUsers();
            var model = _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(userEntity);
            return model;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string id)
        {
            var user = await _repo.GetUser(id);

            if (user == null) return new List<string>();

            var userInRoles = await _userManager
                .GetRolesAsync(user);

            return userInRoles;
        }

        public Task<IdentityResult> ChangePassword(string id, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {

            User userEntity = await _repo.GetUserByUsername(username);
            var model = _mapper.Map<User, UserModel>(userEntity);
            return model;

        }
    }
}
