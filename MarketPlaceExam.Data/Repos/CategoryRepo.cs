using AutoMapper;
using MarketPlace.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceExam.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        // TODO: Make Async
        // TODO: Make Repository for each entity.
        private ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            if (category != null)
            {
               await _context.Categories.AddAsync(category);
               _context.SaveChanges();
            }
        }

        public  async Task<IEnumerable<Category>> GetCategories()
        {
           
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateCategory(Category category)
        {
            var categorylocal = await _context.Categories.FindAsync(category.Id);
            if (categorylocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, Category>());
                var mapper = new Mapper(config);
                categorylocal = mapper.Map<Category>(category);
                _context.SaveChanges();
            }
        }

        public async Task DeleteCategory(int id)
        {
            var categorylocal = await _context.Categories.FindAsync(id);
            if (categorylocal != null)
            {
                _context.Categories.Remove(categorylocal);
                _context.SaveChanges();
            }
        }
    }
}