namespace Marketplace.Services.Interfaces
{
    public interface IMessageService
    {
        Task<bool> Create(string name, string email, string phone, string message);

        
    }
}
