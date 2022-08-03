using AutoMapper;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Repos.Interfaces;
using MarketPlaceExam.Business.Services.Interfaces;

namespace MarketPlaceExam.Business.Services
{
    public class CategoryService : ICategoryService
    {
        // Dependencies
        private ICategoryRepo _repo;

        public CategoryService(ICategoryRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddCategory(CategoryModel category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryModel, Category>());
            var mapper = new Mapper(config);
            var categoryEntity = mapper.Map<CategoryModel, Category>(category);
            await _repo.AddCategory(categoryEntity);
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            Category categoryEntity = await _repo.GetCategory(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Category, CategoryModel>(categoryEntity);
            return model;
        }
        public async Task UpdateCategory(CategoryModel category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryModel, Category>());
            var mapper = new Mapper(config);
            var categoryEntity = mapper.Map<CategoryModel, Category>(category);
            await _repo.UpdateCategory(categoryEntity);
        }

        public async Task DeleteCategory(int id)
        {
            await _repo.DeleteCategory(id);
        }

        public bool IsCategoriesEmpty()
        {
            return _repo.IsCategoriesEmpty();
        }
    }
}