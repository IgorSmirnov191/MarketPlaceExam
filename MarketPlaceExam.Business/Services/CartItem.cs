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
    public class CartItemService : ICartItemService
    {
        // Dependencies
        private ICartItemRepo _repo;

        public CartItemService(ICartItemRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddCartItem(CartItemModel cartitem)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartItemModel, CartItem>());
            var mapper = new Mapper(config);
            var cartitemEntity = mapper.Map<CartItemModel, CartItem>(cartitem);
            await _repo.AddCartItem(cartitemEntity);
        }

        public async Task<CartItemModel> GetCategory(int id)
        {
            CartItem cartitemEntity = await _repo.GetCartItem(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartItem, CartItemModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<CartItem, CartItemModel>(cartitemEntity);
            return model;
        }
        public async Task UpdateCartItem(CartItemModel cartitem)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartItemModel, CartItem>());
            var mapper = new Mapper(config);
            var cartitemEntity = mapper.Map<CartItemModel, CartItem>(cartitem);
            await _repo.UpdateCartItem(cartitemEntity);
        }

        public async Task DeleteCartItem(int id)
        {
            await _repo.DeleteCartItem(id);
        }
    }
}
