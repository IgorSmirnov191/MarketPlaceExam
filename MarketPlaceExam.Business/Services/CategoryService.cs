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

        public Task DeleteCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            Category categoryEntity = await _repo.GetCategory(id);
            var model = _mapper.Map<Category, CategoryModel>(categoryEntity);
            return model;
        }

        public async Task<CategoryModel> GetCategoryByName(string name)
        {
            Category categoryEntity = await _repo.GetCategoryByName(name);
            var model = _mapper.Map<Category, CategoryModel>(categoryEntity);
            return model;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            var categoryEntity = await _repo.GetCategories();
            var model = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categoryEntity);
            return model;
        }

        public async Task<bool> Create(string name, string desc)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            var category = new Category() { Name = name, Description = desc };
            var result = await _repo.AddCategory(category);

            return result;
        }

        public async Task Edit(int id, string name, string desc)
        {
            Category categoryEntity = await _repo.GetCategory(id);
            categoryEntity.Name = name;
            categoryEntity.Description = desc;
            await _repo.UpdateCategory(categoryEntity);

        }
    }
}