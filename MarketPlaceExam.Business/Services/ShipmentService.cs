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
        private IMapper _mapper;
        public ShipmentService(IShipmentRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddShipment(ShipmentModel shipment)
        {
            var shipmentEntity = _mapper.Map<ShipmentModel, Shipment>(shipment);
            await _repo.AddShipment(shipmentEntity);
        }

        public async Task<ShipmentModel> GetShipment(int id)
        {
            Shipment shipmentEntity = await _repo.GetShipment(id);
            var model = _mapper.Map<Shipment, ShipmentModel>(shipmentEntity);
            return model;
        }
        public async Task UpdateShipment(ShipmentModel shipment)
        {
            var shipmentEntity = _mapper.Map<ShipmentModel, Shipment>(shipment);
            await _repo.UpdateShipment(shipmentEntity);
        }

        public async Task DeleteShipment(int id)
        {
            await _repo.DeleteShipment(id);
        }
    }
}
