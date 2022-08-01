using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IShipperRepo
    {
        Task AddShipper(Shipper shipper);
        Task DeleteShipper(int id);
        Task<Shipper> GetShipper(int id);
        Task<IEnumerable<Shipper>> GetShippers();
        Task UpdateShipper(Shipper shipper);
    }
}