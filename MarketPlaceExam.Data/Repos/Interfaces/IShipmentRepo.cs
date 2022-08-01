using MarketPlace.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface IShipmentRepo
    {
        Task AddShipment(Shipment shipment);
        Task DeleteShipment(int id);
        Task<Shipment> GetShipment(int id);
        Task<IEnumerable<Shipment>> GetShipments();
        Task UpdateShipment(Shipment shipment);
    }
}