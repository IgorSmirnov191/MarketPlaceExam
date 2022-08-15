using AutoMapper;
using MarketPlace.MVC.ViewModels.Components;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Components
{
    public class MainHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartService _cartService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MainHeaderViewComponent(UserManager<User> userManager, ICartService cartService, ICategoryService categoryService, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _cartService = cartService;
            _categoryService = categoryService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CurrentUser = HttpContext.User;
            User user = await _userManager.GetUserAsync(CurrentUser);
            IEnumerable<CategoryModel> allCategories = await _categoryService.GetAllCategories();
            
            MainHeaderViewModel result = new MainHeaderViewModel
            {
                ListCategories = allCategories,
            };

            if (user == null)
            {
               var usermodel = await _userService.GetUserByUsername("guest");
               user = _mapper.Map<User>(usermodel);
            }

                var cartModel = await _cartService.GetActiveCart(user.Id);

                result = new MainHeaderViewModel
                {
                    ListCategories = allCategories,
                    CartModel = cartModel,
                };
            
            

            return View(result);
        }
    }
}