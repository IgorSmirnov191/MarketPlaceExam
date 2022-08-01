using AutoMapper;
using MarketPlace.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _context.Shipments.ToListAsync();
        }

        public async Task<Shipment> GetShipment(int id)
        {
            return await _context.Shipments.FindAsync(id);
        }

        public async Task UpdateShipment(Shipment shipment)
        {
            var shipmentlocal = await _context.Shipments.FindAsync(shipment.Id);
            if (shipmentlocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Shipment, Shipment>());
                var mapper = new Mapper(config);
                shipmentlocal = mapper.Map<Shipment>(shipmentlocal);
                _context.SaveChanges();

            }
        }

        public async Task DeleteShipment(int id)
        {
            var shipmentlocal = await _context.Shipments.FindAsync(id);
            if (shipmentlocal != null)
            {
                _context.Shipments.Remove(shipmentlocal);
                _context.SaveChanges();
            }
        }
    }
}
