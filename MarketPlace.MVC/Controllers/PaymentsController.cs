using AutoMapper;
using Marketplace.MVC.ViewModels.Payments;
using MarketPlace.MVC.ViewModels.Payments;
using MarketPlace.MVC.ViewModels.Products;
using MarketPlace.MVC.ViewModels.ShoppingCart;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Controllers
{

    public class PaymentsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPaymentService _paymentService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;
        public PaymentsController(UserManager<User> userManager, IPaymentService paymentService, ICartService cartService, ICartItemService cartItemService, IMapper mapper)
        {
            _userManager = userManager;
            _paymentService = paymentService;
            _cartService= cartService;
            _cartItemService= cartItemService;
             _mapper = mapper;
    }

       
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                MarketPlaceExam.Business.Model.CartModel isCartAny = await _cartService.GetActiveCart(user.Id);
                if (isCartAny != null)
                {
                    PaymentModel paymentmodel = new PaymentModel()
                    {
                        UserId = user.Id,
                        PayUserName = user.FirstName +" "+ user.LastName,
                        PayAddress = user.Address,
                        PayCity = user.City,
                        PayZipCode = user.ZipCode,
                        PayPhoneNumber = user.PhoneNumber,
                        PayEmail = user.Email,
                        ShipAddress = user.ShipAddress,
                        ShipCity = user.ShipCity,
                        ShipZipCode = user.ShipZipCode,
                        ShipPhoneNumber = user.ShipPhoneNumber,
                        ShipEmail = user.ShipEmail,
                        Total = isCartAny.TotalPrice
                    };
                    CreatePaymentInputModel vm = _mapper.Map<CreatePaymentInputModel>(paymentmodel);
                    return View(vm);
                    

                }
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            User user = await _userManager.GetUserAsync(HttpContext.User);
           
            var paymentmodel = _mapper.Map<PaymentModel>(inputModel);
            paymentmodel.UserId = user.Id;
           
            await _paymentService.AddPayment(paymentmodel);
            await _cartService.UpdatePaymentActiveCart(user.Id, paymentmodel.Id);
            return Redirect("/"); ;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyPayments()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            var resultModel = _paymentService.GetAllPaymentsByUserId<MyPaymentsViewModel>(user.Id).ToList(); 

            return View(resultModel);
        }
    }
}
