using AutoMapper;
using MarketPlace.Entities;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Data.Repos.Interfaces;

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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, Category>());
            var mapper = new Mapper(config);
            var categoryEntity = mapper.Map<Category>(category);

            //Category categoryEntity = new Category
            //{
            //    Description = category.Description,
            //    Name = category.Name,
            //    Id = category.Id,
            //};

            await _repo.AddCategory(categoryEntity);
        }

        public async Task<CategoryModel> GetCategory(int id)
        {

            Category categoryEntity = await _repo.GetCategory(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<CategoryModel>(categoryEntity);

            //CategoryModel model = new CategoryModel
            //{
            //    Description = categoryEntity.Description,
            //    Id = categoryEntity.Id,
            //    Name = categoryEntity.Name,
            //};

            return model;
        }
    }
}