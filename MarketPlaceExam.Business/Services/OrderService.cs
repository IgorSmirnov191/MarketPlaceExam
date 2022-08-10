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
            Order orderEntity = _mapper.Map<OrderModel, Order>(order);
            await _repo.AddOrder(orderEntity);
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            Order orderEntity = await _repo.GetOrder(id);
            OrderModel model = _mapper.Map<Order, OrderModel>(orderEntity);
            return model;
        }
        public async Task UpdateOrder(OrderModel order)
        {
            Order orderEntity = _mapper.Map<OrderModel, Order>(order);
            await _repo.UpdateOrder(orderEntity);
        }

        public async Task DeleteOrder(int id)
        {
            await _repo.DeleteOrder(id);
        }

       
        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            IEnumerable<Order> orderEntity = await _repo.GetOrders();
            IEnumerable<OrderModel> model = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orderEntity);
            return model;
        }

        public async Task<IEnumerable<OrderModel>> GetMyOrders(string userId)
        {
            IEnumerable<Order> orderEntity = await _repo.GetMyOrders(userId);
            IEnumerable<OrderModel> model = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orderEntity);
            return model;
        }
    
    }
}
