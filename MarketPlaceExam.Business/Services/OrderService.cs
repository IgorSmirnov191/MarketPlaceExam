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
    public class OrderService : IOrderService
    {
        // Dependencies
        private IOrderRepo _repo;

        public OrderService(IOrderRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddOrder(OrderModel category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, Order>());
            var mapper = new Mapper(config);
            var orderEntity = mapper.Map<OrderModel, Order>(category);
            await _repo.AddOrder(orderEntity);
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            Order orderEntity = await _repo.GetOrder(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Order, OrderModel>(orderEntity);
            return model;
        }
        public async Task UpdateOrder(OrderModel order)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, Order>());
            var mapper = new Mapper(config);
            var orderEntity = mapper.Map<OrderModel, Order>(order);
            await _repo.UpdateOrder(orderEntity);
        }

        public async Task DeleteOrder(int id)
        {
            await _repo.DeleteOrder(id);
        }
    }
}
