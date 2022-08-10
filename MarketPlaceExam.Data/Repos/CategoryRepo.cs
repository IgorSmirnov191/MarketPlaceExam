using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

namespace MarketPlaceExam.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
      
        public ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategory(Category category)
        {
            var result = 0;
            if (category != null)
            {
              await _context.Categories.AddAsync(category);
               result = await _context.SaveChangesAsync();
            }
            return result>0; 
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

            if (category != null)
            {
                _context.Categories.Update(category);
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

        public bool IsCategoriesEmpty()
        {
            return _context.Categories.Any();
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return await _context
                .Categories
                .SingleOrDefaultAsync(x=>x.Name == name);
        }

        public async Task Edit(int id, string name, string description)
        {
            if (id == 0 || string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            var category = await GetCategory(id);
            if (category == null)
            {
                return;
            }

            category.Name = name;
            category.Description = description;

           await UpdateCategory(category);
          
        }
    }
}