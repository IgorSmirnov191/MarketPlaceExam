using AutoMapper;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Repos.Interfaces;
using MarketPlaceExam.Business.Services.Interfaces;

namespace MarketPlaceExam.Business.Services
{
    public class CartService : ICartService
    {
        // Dependencies
        private ICartRepo _repo;

        public CartService(ICartRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddCart(CartModel cart)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartModel, Cart>());
            var mapper = new Mapper(config);
            var cartEntity = mapper.Map<CartModel, Cart>(cart);
            await _repo.AddCart(cartEntity);
        }

        public async Task<CartModel> GetCart(int id)
        {
            Cart cartEntity = await _repo.GetCart(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cart, CartModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Cart, CartModel>(cartEntity);
            return model;
        }
        public async Task UpdateCart(CartModel cart)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CartModel, Cart>());
            var mapper = new Mapper(config);
            var cartEntity = mapper.Map<CartModel, Cart>(cart);
            await _repo.UpdateCart(cartEntity);
        }

        public async Task DeleteCart(int id)
        {
            await _repo.DeleteCart(id);
        }

        public bool IsCartsEmpty()
        {
            return _repo.IsCartsEmpty();
        }
    }
}
