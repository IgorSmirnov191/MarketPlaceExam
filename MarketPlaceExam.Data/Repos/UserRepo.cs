using AutoMapper;
using MarketPlace.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext _context;


        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUser(User user)
        {
            var userlocal = await _context.Users.FindAsync(user.Id);
            if(userlocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, User>());
                var mapper = new Mapper(config);
                userlocal = mapper.Map<User>(user);
                _context.SaveChanges();

            }
        }

        public async Task DeleteUser(int id)
        {
            var userlocal = await _context.Users.FindAsync(id);
            if (userlocal != null)
            {
                _context.Users.Remove(userlocal);
                _context.SaveChanges();
            }
        }
    }
}
