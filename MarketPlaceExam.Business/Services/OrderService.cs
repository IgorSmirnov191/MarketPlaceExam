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
       
        private IMapper _mapper;

        public OrderService(IOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddOrder(OrderModel order)
        {
            var orderEntity = _mapper.Map<OrderModel, Order>(order);
            await _repo.AddOrder(orderEntity);
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            Order orderEntity = await _repo.GetOrder(id);
            var model = _mapper.Map<Order, OrderModel>(orderEntity);
            return model;
        }
        public async Task UpdateOrder(OrderModel order)
        {
            var orderEntity = _mapper.Map<OrderModel, Order>(order);
            await _repo.UpdateOrder(orderEntity);
        }

        public async Task DeleteOrder(int id)
        {
            await _repo.DeleteOrder(id);
        }

       
        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            var orderEntity = await _repo.GetOrders();
            var model = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orderEntity);
            return model;
        }

        public async Task<IEnumerable<OrderModel>> GetMyOrders(string userId)
        {
            var orderEntity = await _repo.GetMyOrders(userId);
            var model = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orderEntity);
            return model;
        }
    
    }
}
