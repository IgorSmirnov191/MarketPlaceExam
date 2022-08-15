using MarketPlace.MVC.ViewModels.Components;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Components
{
    [ViewComponent]
    public class MainNavigationMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public MainNavigationMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<CategoryModel> allCategories = await _categoryService.GetAllCategories();
            MainNavigationMenuViewModel resultModel = new MainNavigationMenuViewModel()
            {
                Categories = allCategories
            };

            return View(resultModel);
        }
    }
}