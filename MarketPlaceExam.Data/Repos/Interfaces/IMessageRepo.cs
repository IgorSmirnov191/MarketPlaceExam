namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IMessageRepo
    {
        Task<bool> Create(string name, string email, string phone, string messageContent);
    }
}