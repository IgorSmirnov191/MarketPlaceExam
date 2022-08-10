using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

namespace MarketPlaceExam.Data.Repos
{
    public class ShipmentRepo : IShipmentRepo
    {
        private ApplicationDbContext _context;

        public ShipmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task AddShipment(Shipment shipment)
        {
            if (shipment != null)
            {
                await _context.Shipments.AddAsync(shipment);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<Shipment>> GetShipments()
        {
            return await _context
                .Shipments
                .Include(x=> x.Order)
                .Include(x=> x.Shipper)
                .ToListAsync();
        }

        public async Task<Shipment> GetShipment(int id)
        {
            return await _context.Shipments.FindAsync(id);
        }

        public async Task UpdateShipment(Shipment shipment)
        {
            if (shipment != null)
            {
                _context.Shipments.Update(shipment);
                _context.SaveChanges();
            }
        }

        public async Task DeleteShipment(int id)
        {
            Shipment? shipmentlocal = await _context.Shipments.FindAsync(id);
            if (shipmentlocal != null)
            {
                _context.Shipments.Remove(shipmentlocal);
                _context.SaveChanges();
            }
        }
    }
}
