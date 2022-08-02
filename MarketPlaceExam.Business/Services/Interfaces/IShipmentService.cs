using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface IShipmentService
    {
        Task AddShipment(ShipmentModel shipment);
        Task DeleteShipment(int id);
        Task<ShipmentModel> GetShipment(int id);
        Task UpdateShipment(ShipmentModel shipment);
    }
}