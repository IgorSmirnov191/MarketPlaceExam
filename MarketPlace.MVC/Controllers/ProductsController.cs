using AutoMapper;
using MarketPlace.MVC.Infrastructure;
using MarketPlace.MVC.ViewModels.Products;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketPlace.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly IStockService _stockService;
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        public ProductsController(IMapper mapper, UserManager<User> userManager, ICategoryService categoryService, IStockService stockService, IProductService productService, IPictureService pictureService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _categoryService = categoryService;
            _stockService = stockService;
            _productService = productService;
            _pictureService = pictureService;
        }

        public IActionResult All()
        {
            var resultModel =  _stockService.GetAllStockProducts<AllProductViewModel>().ToList();

            return this.View(resultModel);
        }

       
        [Authorize]
        public async Task<IActionResult> Create()
        {
            CreateProductInputModel inputModel = await PrepareCreateProductInputModel();

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel = await PrepareCreateProductInputModel();

                return this.View(inputModel);
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var product = new Product()
            {
                Name = inputModel.Name,
                Price = inputModel.Price,
                Description = inputModel.Description,
            };

            var stock = new Stock()
            {
                ProductId = product.Id,
                Product = product,
                Quantity = inputModel.Quantity,
               
            };
            var model = _mapper.Map<Stock,StockModel>(stock);
            bool isProductAdded = await _stockService.AddProductToStock(model);
            if (!isProductAdded)
            {
                inputModel = await PrepareCreateProductInputModel();

                return this.View(inputModel);
            }

            CategoryModel category = await _categoryService.GetCategoryByName(inputModel.CategoryName);
            await _stockService.AddCategoryToProduct(product.Id, category);

            var picturePath = await _pictureService
                .SavePicture(product.Id, inputModel.Picture, GlobalConstants.DefaultPicturesPath);

            await _stockService.AddPicturePath(product.Id, picturePath);

            return this.RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _stockService.GetFromStockByProductId(id);
            if (product == null)
            {
                return NotFound();
            }

            var resultModel = _mapper.Map<DetailsProductViewModel>(product);
                  

            return this.View(resultModel);
       
       
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _stockService.GetFromStockByProductId(id);
            if (product == null)
            {
                return Redirect("/");
            }

            var allCategories = await _categoryService.GetAllCategories();
            var categories = allCategories.Select(x => new SelectListItem() { Text = x.Name }).ToList();
            var inputModel = _mapper.Map<EditProductInputModel>(product);
            inputModel.Categories = categories;

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                var allCategories = await _categoryService.GetAllCategories();
                var categories = allCategories.Select(x => new SelectListItem() { Text = x.Name }).ToList();
                inputModel.Categories = categories;

                return this.View(inputModel);
            }

            var product = _mapper.Map<ProductModel>(inputModel);

            var user = await _userManager.GetUserAsync(HttpContext.User);
           
            var category = await _categoryService.GetCategoryByName(inputModel.CategoryName);

            product.CategoryId = category.Id;

             await _productService.UpdateProduct(product);

            var picturePath = await _pictureService
                .SavePicture(product.Id, inputModel.Picture, GlobalConstants.DefaultPicturesPath);

            await _productService.EditPicturePath(product.Id, picturePath);

            return this.RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> AddPicture(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            var inputModel = new AddPictureProductInputModel() { Id = product.Id };

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPicture(AddPictureProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var picturePath = await _pictureService
               .SavePicture(inputModel.Id, inputModel.Picture, GlobalConstants.DefaultPicturesPath);

            await _stockService.AddPicturePath(inputModel.Id, picturePath);

            return this.Redirect($"/Products/Details/{inputModel.Id}");
        }


        private async Task<CreateProductInputModel> PrepareCreateProductInputModel()
        {
            var allCategories = await _categoryService.GetAllCategories();
            var categories = allCategories.Select(x => new SelectListItem() { Text = x.Name }).ToList();

            var inputModel = new CreateProductInputModel() { Categories = categories };
            return inputModel;
        }
    }
}
