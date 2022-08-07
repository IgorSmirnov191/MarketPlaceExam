using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;

namespace MarketPlaceExam.Business.Services
{
    public class CartItemService : ICartItemService
    {
        // Dependencies
        private ICartItemRepo _repo;
        private IMapper _mapper;

        public CartItemService(ICartItemRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddCartItem(CartItemModel cartitem)
        {
            var cartitemEntity = _mapper.Map<CartItemModel, CartItem>(cartitem);
            await _repo.AddCartItem(cartitemEntity);
        }

        public async Task<CartItemModel> GetCategory(int id)
        {
            CartItem cartitemEntity = await _repo.GetCartItem(id);
            var model = _mapper.Map<CartItem, CartItemModel>(cartitemEntity);
            return model;
        }

        public async Task UpdateCartItem(CartItemModel cartitem)
        {
            var cartitemEntity = _mapper.Map<CartItemModel, CartItem>(cartitem);
            await _repo.UpdateCartItem(cartitemEntity);
        }

        public async Task DeleteCartItem(int id)
        {
            await _repo.DeleteCartItem(id);
        }

        public bool IsCartItemsEmpty()
        {
            return _repo.IsCartItemsEmpty();
        }
    }
}