using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
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
        private IUserRepo _repo;
        private IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddUser(UserModel user)
        {
            var userEntity = _mapper.Map<UserModel, User>(user);
            await _repo.AddUser(userEntity);
        }

        public async Task<UserModel> GetUser(int id)
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

        public async Task DeleteUser(int id)
        {
            await _repo.DeleteUser(id);
        }

        public bool IsUsersEmpty()
        {
            return _repo.IsUsersEmpty();
        }
    }
}
