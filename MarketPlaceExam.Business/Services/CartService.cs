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
        private IMapper _mapper;

        public CartService(ICartRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddCart(CartModel cart)
        {
            var cartEntity = _mapper.Map<CartModel, Cart>(cart);
            await _repo.AddCart(cartEntity);
        }

        public async Task<CartModel> GetCart(int id)
        {
            Cart cartEntity = await _repo.GetCart(id);
            var model = _mapper.Map<Cart, CartModel>(cartEntity);
            return model;
        }
        public async Task UpdateCart(CartModel cart)
        {
            var cartEntity = _mapper.Map<CartModel, Cart>(cart);
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

        public async Task<CartModel> GetActiveCart(string userid)
        {
            Cart cartEntity = await _repo.GetActiveCart(userid);
            var model = _mapper.Map<Cart, CartModel>(cartEntity);
            return model;
        }
    }
}
