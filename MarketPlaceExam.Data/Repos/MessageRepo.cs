
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Data;
using MarketPlaceExam.Data.Repos.Interfaces;

namespace MarketPlaceExam.Data.Repos
{
    public class MessageRepo : IMessageRepo
    {
        private ApplicationDbContext _context;

        public MessageRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(string name, string email, string phone, string messageContent)
        {
            var message = new Message()
            {
                Name = name,
                Email = email,
                Phone = phone,
                MessageContent = messageContent,
                IssuedOn = DateTime.UtcNow,

            };

            _context.Messages.Add(message);
            var result = await _context.SaveChangesAsync();


            return result > 0;
        }
    }
}
