using Marketplace.App.ViewModels.Components;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Components
{
    public class MainHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartService _cartService;
        private readonly ICategoryService _categoryService;

        public MainHeaderViewComponent(UserManager<User> userManager, ICartService cartService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<CategoryModel> allCategories = await _categoryService.GetAllCategories();
            
            MainHeaderViewModel result = new MainHeaderViewModel
            {
                ListCategories = allCategories,
            };

            if (user != null)
            {
                var cartModel = await _cartService.GetActiveCart(user.Id);

                result = new MainHeaderViewModel
                {
                    ListCategories = allCategories,
                    CartModel = cartModel,
                };
            }

            return View(result);
        }
    }
}