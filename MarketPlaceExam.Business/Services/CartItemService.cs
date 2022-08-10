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
            CartItem cartitemEntity = _mapper.Map<CartItemModel, CartItem>(cartitem);
            await _repo.AddCartItem(cartitemEntity);
        }

        public async Task<CartItemModel> GetCartItem(int id)
        {
            CartItem cartitemEntity = await _repo.GetCartItem(id);
            CartItemModel model = _mapper.Map<CartItem, CartItemModel>(cartitemEntity);
            return model;
        }

        public async Task UpdateCartItem(CartItemModel cartitem)
        {
            CartItem cartitemEntity = _mapper.Map<CartItemModel, CartItem>(cartitem);
            await _repo.UpdateCartItem(cartitemEntity);
        }

        public async Task DeleteCartItem(int id)
        {
            await _repo.DeleteCartItem(id);
        }

        public async Task<IEnumerable<CartItemModel>> GetAllCartItemsByCart(int cartid)
        {
            IEnumerable<CartItem> cartitemEntity = await _repo.GetAllCartItemsByCart(cartid);
            IEnumerable<CartItemModel> model = _mapper.Map<IEnumerable<CartItem>, IEnumerable<CartItemModel>>(cartitemEntity);
            return model;
        }
        public bool IsCartItemsEmpty()
        {
            return _repo.IsCartItemsEmpty();
        }
    }
}