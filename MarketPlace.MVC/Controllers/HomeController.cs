using AutoMapper;
using Marketplace.App.Infrastructure;
using Marketplace.App.ViewModels.Home;
using MarketPlace.MVC.Models;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Marketplace.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(IMapper mapper, ICategoryService categoryService, IProductService productService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductModel> allProducts = await _productService.GetAllProducts();
            List<HomeProductViewModel> listProducts = new List<HomeProductViewModel>();
            foreach (ProductModel product in allProducts)
            {
                listProducts.Add(new HomeProductViewModel() { Id = product.Id, Name = product.Name, Price = product.Price, PictureUrl = product.Picture.Uri });
            }

            HomeIndexViewModel resultModel = new HomeIndexViewModel()
            {
                Products = listProducts
            };

            return View(resultModel);
        }

        [HttpGet]
        public IActionResult Search(HomeSearchInputModel inputModel)
        {
            List<HomeProductViewModel> listProducts = new List<HomeProductViewModel>();
            ViewData["ProductsHead"] = GlobalConstants.HeadTextForFoundResult;
            if (inputModel.Input == string.Empty && inputModel.CategoryName == GlobalConstants.SearchCategoryDefaultValue)
            {
                return Redirect(nameof(Index));
            }

            return View(new List<HomeSearchViewModel>());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}