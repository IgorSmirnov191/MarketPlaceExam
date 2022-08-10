using Marketplace.App.ViewModels.Components;
using MarketPlaceExam.Business.Services;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public SideBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allCategories = await _categoryService.GetAllCategories();
            List<SideBarCategoryViewModel> listCategories = new List<SideBarCategoryViewModel>();
            foreach (var category in allCategories)
            {
                listCategories.Add(new SideBarCategoryViewModel() { Id = category.Id, Name = category.Name });
            }
            var resultModel = new SideBarViewModel() { Categories = listCategories };

            return this.View(resultModel);
        }
    }
}
