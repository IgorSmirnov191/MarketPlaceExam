using Marketplace.Services.Interfaces;
using MarketPlaceExam.Data.Repos.Interfaces;

namespace MarketPlaceExam.Business.Services
{
    public class MessageService : IMessageService
    {
        private IMessageRepo _repo;
      
       
        public MessageService(IMessageRepo repo)
        {
            _repo = repo;
          
        }

        public async Task<bool> Create( string name, string email, string phone, string messageContent)
        {
           return await _repo.Create(name, email, phone, messageContent); 
        }

        
    }
}
