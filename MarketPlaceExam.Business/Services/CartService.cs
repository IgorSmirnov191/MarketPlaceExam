using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;

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
            Cart cartEntity = _mapper.Map<CartModel, Cart>(cart);
            await _repo.AddCart(cartEntity);
        }

        public async Task<CartModel> GetCart(int id)
        {
            Cart cartEntity = await _repo.GetCart(id);
            CartModel model = _mapper.Map<Cart, CartModel>(cartEntity);
            return model;
        }

        public async Task UpdateCart(CartModel cart)
        {
            Cart cartEntity = _mapper.Map<CartModel, Cart>(cart);
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
            CartModel model = _mapper.Map<Cart, CartModel>(cartEntity);
            return model;
        }

        public async Task ClearCart(int id)
        {
            await _repo.ClearCart(id);
        }

        public async Task UpdatePaymentActiveCart(string userid, int paymentid)
        {
            await _repo.UpdatePaymentActiveCart(userid, paymentid);
        }


        // TODO: Duplicate method. Can be done in MAPPER

        //public async Task<ShoppingCartModel> GetShoppingCartModel(User user)
        //{
        //    ShoppingCartModel result;

        //    if (user == null)
        //    {
        //        result = new ShoppingCartModel()
        //        {
        //            ShoppingCartProductCount = 0,
        //            ShoppingCartTotalPrice = 0.00M
        //        };
        //    }
        //    else
        //    {
        //        result = await GetItemsInUserCart(user.Id);
        //    }

        //    return result;
        //}

        //private async Task<ShoppingCartModel> GetItemsInUserCart(string userId)
        //{

        //    CartModel cart = await GetActiveCart(userId);

        //    return new ShoppingCartModel()
        //    {
        //        ShoppingCartProductCount = cart.TotalAmountOfItemsInCart,
        //        ShoppingCartTotalPrice = cart.TotalPrice,
        //    };
        //}
    }
}