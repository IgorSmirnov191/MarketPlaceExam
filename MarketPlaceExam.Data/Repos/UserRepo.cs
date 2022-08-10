using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

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
            if (user != null)
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUser(User user)
        {
            if (user != null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string id)
        {
            var userlocal = await _context.Users.FindAsync(id);
            if (userlocal != null)
            {
                _context.Users.Remove(userlocal);
                _context.SaveChanges();
            }
        }
        public bool IsUsersEmpty()
        {
            return _context.Users.Any();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context
                .Users
                .SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
