using AutoMapper;
using MarketPlace.MVC.ViewModels.ShoppingCart;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IProductService _productService;  

        public CartController(ICartService cartService, IMapper mapper, UserManager<User> manager, IUserService userService, ICartItemService cartItemService, IProductService productService)
        {
            _cartService = cartService;
            _mapper = mapper;
            _userManager = manager;
            _userService = userService;
            _cartItemService = cartItemService;
            _productService = productService;   
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CartModel model;
            CartViewModel vm;
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var usermodel = await _userService.GetUserByUsername("guest");
                user = _mapper.Map<User>(usermodel);
            }
               
                model = await _cartService.GetActiveCart(user.Id);

                vm = _mapper.Map<CartViewModel>(model);
                return View(vm);
          
        }

      
        public async Task<ActionResult> Cart()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var usermodel = await _userService.GetUserByUsername("guest");
                user = _mapper.Map<User>(usermodel);
            }

            CartModel model = await _cartService.GetActiveCart(user.Id);

            CartViewModel vm = _mapper.Map<CartViewModel>(model);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                var usermodel = await _userService.GetUserByUsername("guest");
                user = _mapper.Map<User>(usermodel);
            }

            CartModel cartmodel = await _cartService.GetActiveCart(user.Id);
            ProductModel productmodel = await _productService.GetProduct(id);
            bool updateresult = await _cartItemService.UpdateQuantityCartItemFromCartByProductId(cartmodel.Id, productmodel.Id, quantity);


            if (!updateresult)
            {
                CartItemModel cartitemmodel = new CartItemModel()
                {
                    CartId = cartmodel.Id,
                    ProductId = productmodel.Id,
                    Quantity = quantity
                };
                await _cartItemService.AddCartItem(cartitemmodel);
            }
            
           
           
            return this.Redirect("/");
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return RedirectToAction(nameof(Index));
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/ClearCart
        public ActionResult ClearCart(int id)
        {
           _cartService.ClearCart(id);

            return this.Redirect("/");
        }
        // GET: CartController/Remove/5
        public async Task<ActionResult> Remove(int id)
        {
            bool ret = await _cartItemService.DeleteCartItem(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: CartController/Add/5
        public async Task<ActionResult> Add(int id)
        {
            bool ret = await _cartItemService.UpdateQuantityCartItemById(id, 1);
            return RedirectToAction(nameof(Index));
        }
        // GET: CartController/Minus/5
        public async Task<ActionResult> Minus(int id)
        {
            bool ret = await _cartItemService.UpdateQuantityCartItemById(id, -1);
            return RedirectToAction(nameof(Index));
        }
        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}