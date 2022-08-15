using AutoMapper;
using MarketPlace.MVC.Infrastructure;
using MarketPlace.MVC.Models;
using MarketPlace.MVC.ViewModels.Home;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketPlace.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IStockService _stockService;

        public HomeController(IMapper mapper, ICategoryService categoryService, IProductService productService, IStockService stockService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
            _stockService = stockService;
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
            if ( String.IsNullOrEmpty(inputModel.Input) && inputModel.CategoryName == GlobalConstants.SearchCategoryDefaultValue)
            {
                return Redirect(nameof(Index));
            }
            else if (!String.IsNullOrEmpty(inputModel.Input) && inputModel.CategoryName != GlobalConstants.SearchCategoryDefaultValue)
            {
                var resultModel = _stockService.GetStockProductByInputAndCategoryName<HomeSearchViewModel>(inputModel.Input, inputModel.CategoryName).ToList();

                return this.View(resultModel);
            }
            else if (!String.IsNullOrEmpty(inputModel.Input))
            {
                var resultModel = _stockService.GetStockProductByInput<HomeSearchViewModel>(inputModel.Input).ToList();

                return this.View(resultModel);
            }
            else if (inputModel.CategoryName != GlobalConstants.SearchCategoryDefaultValue)
            {
                var resultModel = _stockService.GetStockProductsByCategoryName<HomeSearchViewModel>(inputModel.CategoryName).ToList();

                return this.View(resultModel);
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