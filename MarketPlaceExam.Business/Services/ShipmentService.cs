using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Services
{
    public class ShipmentService : IShipmentService
    {
        // Dependencies
        private IShipmentRepo _repo;

        public ShipmentService(IShipmentRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddShipment(ShipmentModel shipment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShipmentModel, Shipment>());
            var mapper = new Mapper(config);
            var shipmentEntity = mapper.Map<ShipmentModel, Shipment>(shipment);
            await _repo.AddShipment(shipmentEntity);
        }

        public async Task<ShipmentModel> GetShipment(int id)
        {
            Shipment shipmentEntity = await _repo.GetShipment(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Shipment, ShipmentModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Shipment, ShipmentModel>(shipmentEntity);
            return model;
        }
        public async Task UpdateShipment(ShipmentModel shipment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShipmentModel, Shipment>());
            var mapper = new Mapper(config);
            var shipmentEntity = mapper.Map<ShipmentModel, Shipment>(shipment);
            await _repo.UpdateShipment(shipmentEntity);
        }

        public async Task DeleteShipment(int id)
        {
            await _repo.DeleteShipment(id);
        }
    }
}
