using Marketplace.App.ViewModels.Orders;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Controllers
{

    public class OrdersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;

        public OrdersController(UserManager<User> userManager, IOrderService orderService, ICartService cartService, ICartItemService cartItemService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _cartService= cartService;
            _cartItemService= cartItemService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                MarketPlaceExam.Business.Model.CartModel isCartAny = await _cartService.GetActiveCart(user.Id);
                if (isCartAny != null)
                {
                    return Redirect("/ShoppingCart/Cart");
                }
            }

            return View();
        } 

        

        [Authorize]
        [HttpGet]
        public IActionResult SuccessfulOrder()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            Task<IEnumerable<MarketPlaceExam.Business.Model.OrderModel>> resultModel = _orderService.GetMyOrders(user.Id); 

            return View(resultModel);
        }
    }
}
