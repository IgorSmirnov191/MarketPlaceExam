using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

namespace MarketPlaceExam.Data.Repos
{
    public class ShipperRepo : IShipperRepo
    {
        private ApplicationDbContext _context;

        public ShipperRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task AddShipper(Shipper shipper)
        {
            if (shipper != null)
            {
                await _context.Shippers.AddAsync(shipper);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            return await _context.Shippers.ToListAsync();
        }

        public async Task<Shipper> GetShipper(int id)
        {
            return await _context.Shippers.FindAsync(id);
        }

        public async Task UpdateShipper(Shipper shipper)
        {
            if (shipper != null)
            {
                _context.Shippers.Update(shipper);
                _context.SaveChanges();
            }

        }

        public async Task DeleteShipper(int id)
        {
            var shipperlocal = await _context.Shippers.FindAsync(id);
            if (shipperlocal != null)
            {
                _context.Shippers.Remove(shipperlocal);
                _context.SaveChanges();
            }
        }
        public bool IsShippersEmpty()
        {
            return _context.Shippers.Any();
        } 
    }
}
