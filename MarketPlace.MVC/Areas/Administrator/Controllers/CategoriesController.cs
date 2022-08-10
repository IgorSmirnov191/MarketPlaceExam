using AutoMapper;
using Marketplace.App.Areas.Administrator.ViewModels.Categories;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.App.Areas.Administrator.Controllers
{
    public class CategoriesController : AdministratorController
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult All()
        {
            Task<IEnumerable<CategoryModel>> resultModel = categoryService.GetAllCategories();

            return View(resultModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool result = await categoryService.Create(inputModel.Name,inputModel.Description);
            if (!result)
            {
                return Redirect("/");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CategoryModel category = await categoryService.GetCategoryById(id);
            if (category == null)
            {
                return RedirectToAction(nameof(All));
            }
            EditCategoryInputModel resultModel = mapper.Map<EditCategoryInputModel>(category);

            return View(resultModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, EditCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            await categoryService.Edit(id, inputModel.Name, inputModel.Description);

            return RedirectToAction(nameof(All));
        }
    }
}
