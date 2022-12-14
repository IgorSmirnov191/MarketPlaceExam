using MarketPlace.MVC.ViewModels.Components;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Components
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
            IEnumerable<MarketPlaceExam.Business.Model.CategoryModel> allCategories = await _categoryService.GetAllCategories();
            List<SideBarCategoryViewModel> listCategories = new List<SideBarCategoryViewModel>();
            foreach (MarketPlaceExam.Business.Model.CategoryModel category in allCategories)
            {
                listCategories.Add(new SideBarCategoryViewModel() { Id = category.Id, Name = category.Name });
            }
            SideBarViewModel resultModel = new SideBarViewModel() { Categories = listCategories };

            return View(resultModel);
        }
    }
}
