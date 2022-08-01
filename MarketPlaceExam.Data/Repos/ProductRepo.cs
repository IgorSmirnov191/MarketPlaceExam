using AutoMapper;
using MarketPlaceExam.Data.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _context.Products.ToListAsync();
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
    }
}
