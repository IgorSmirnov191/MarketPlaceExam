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
        private readonly ICategoryService _categoryService;
        private readonly ICartItemService _cartitemService;
        private readonly ICartService _cartService;

        public MainHeaderViewComponent(UserManager<User> userManager, ICategoryService categoryService, ICartItemService cartitemService, ICartService cartService)
        {
            _userManager = userManager;
            _categoryService = categoryService;
            _cartitemService = cartitemService;
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Mapping
            IEnumerable<CategoryModel> allCategories = await _categoryService.GetAllCategories();
            List<IndexCategoryViewModel> listCategories = new List<IndexCategoryViewModel>();

            foreach (CategoryModel category in allCategories)
            {
                listCategories.Add(new IndexCategoryViewModel() { Id = category.Id, Name = category.Name });
            }

            User user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                CartModel cart = await _cartService.GetActiveCart(user.Id);
                IEnumerable<CartItemModel> cartitems = await _cartitemService.GetAllCartItemsByCart(cart.Id);
                decimal itemsTotal = 0.0m;

                foreach (CartItemModel cartitem in cartitems)
                {
                    itemsTotal += cartitem.Product.Price * cartitem.Quantity;
                }

                MainHeaderViewModel resultModel = new MainHeaderViewModel()
                {
                    ListCategories = listCategories,
                    ShoppingCartProductCount = cartitems.Count(),
                    ShoppingCartTotalPrice = itemsTotal
                };

                return View(resultModel);
            }

            MainHeaderViewModel resultModelIfNull = new MainHeaderViewModel()
            {
                ListCategories = listCategories,
                ShoppingCartProductCount = 0,
                ShoppingCartTotalPrice = 0.00M
            };

            return View(resultModelIfNull);
        }
    }
}