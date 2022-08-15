using MarketPlace.MVC.ViewModels.Categories;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IStockService _stockService;

        public CategoryController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public IActionResult Category(int id, string name)
        {
            if(id == 0)
            {
                return this.Redirect("/");
            }

            var resultModel = _stockService.GetStockProductsByCategoryId<CategoriesProductViewModel>(id).ToList();
            ViewData["ProductsHead"] = name;

            return View(resultModel);
        }
    }
}
