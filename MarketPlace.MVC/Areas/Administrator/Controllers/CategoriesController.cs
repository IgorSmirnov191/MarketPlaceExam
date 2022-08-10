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
            var resultModel = this.categoryService.GetAllCategories();

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
                return this.View(inputModel);
            }

            var result = await this.categoryService.Create(inputModel.Name,inputModel.Description);
            if (!result)
            {
                return this.Redirect("/");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await this.categoryService.GetCategoryById(id);
            if (category == null)
            {
                return this.RedirectToAction(nameof(All));
            }
            var resultModel = this.mapper.Map<EditCategoryInputModel>(category);

            return this.View(resultModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, EditCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoryService.Edit(id, inputModel.Name, inputModel.Description);

            return RedirectToAction(nameof(All));
        }
    }
}
