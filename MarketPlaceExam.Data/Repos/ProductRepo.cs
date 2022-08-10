using MarketPlaceExam.Data.Data;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceExam.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            if (product != null)
            {
                await _context.Products.AddAsync(product);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                .Products
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .Include(x => x.Picture)
                .ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var productlocal = await _context.Products.FindAsync(id);
            if (productlocal != null)
            {
                _context.Products.Remove(productlocal);
                _context.SaveChanges();
            }
        }

        public bool IsProductsEmpty()
        {
            return _context.Products.Any();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierId(int supplierId)
        {
            return await _context
                .Products
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .Include(x => x.Picture)
                .Where(x => x.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context
               .Products
               .Include(x => x.Supplier)
               .Include(x => x.Category)
               .Include(x => x.Picture)
               .Where(x => x.CategoryId == categoryId)
               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAndCategory(string name, string category)
        {
            return await _context
               .Products
               .Include(x => x.Supplier)
               .Include(x => x.Category)
               .Include(x => x.Picture)
               .Where(x => x.Name == name)
               .Where(x => x.Category.Name == category)
               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _context
                .Products
                .Include(x => x.Supplier)
                .Include(x => x.Category)
                .Include(x => x.Picture)
                .Where(x => x.Name == name)
                .ToListAsync();
        }
    }
}