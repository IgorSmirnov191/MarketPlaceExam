﻿using AutoMapper;
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
        private IMapper _mapper;

        public CategoryService(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryModel category)
        {
          
            var categoryEntity = _mapper.Map<CategoryModel, Category>(category);
            await _repo.AddCategory(categoryEntity);
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            Category categoryEntity = await _repo.GetCategory(id);
            var model = _mapper.Map<Category, CategoryModel>(categoryEntity);
            return model;
        }
        public async Task UpdateCategory(CategoryModel category)
        {
            var categoryEntity = _mapper.Map<CategoryModel, Category>(category);
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