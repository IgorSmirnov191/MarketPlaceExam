using Marketplace.App.ViewModels.Components;
using MarketPlaceExam.Business.Services;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Components
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
            var allCategories = await _categoryService.GetAllCategories();
            List<IndexCategoryViewModel> listCategories = new List<IndexCategoryViewModel>();
            foreach (var category in allCategories)
            {
                listCategories.Add(new IndexCategoryViewModel() { Id = category.Id, Name = category.Name });
            }
           
            var resultModel = new MainNavigationMenuViewModel()
            {
                Categories = listCategories
            };

            return View(resultModel);
        }
    }
}
