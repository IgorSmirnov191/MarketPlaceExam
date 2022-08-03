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

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddUser(UserModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
            var mapper = new Mapper(config);
            var userEntity = mapper.Map<UserModel, User>(user);
            await _repo.AddUser(userEntity);
        }

        public async Task<UserModel> GetUser(int id)
        {
            User userEntity = await _repo.GetUser(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<User, UserModel>(userEntity);
            return model;
        }
        public async Task UpdateUser(UserModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
            var mapper = new Mapper(config);
            var userEntity = mapper.Map<UserModel, User>(user);
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
