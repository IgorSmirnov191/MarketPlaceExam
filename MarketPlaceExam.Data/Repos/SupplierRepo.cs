using AutoMapper;
using MarketPlace.Entities;
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
    public class SupplierRepo : ISupplierRepo
    {
        private ApplicationDbContext _context;

        public SupplierRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                await _context.Suppliers.AddAsync(supplier);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            var supplierlocal = await _context.Suppliers.FindAsync(supplier.Id);
            if (supplierlocal != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, Supplier>());
                var mapper = new Mapper(config);
                supplierlocal = mapper.Map<Supplier>(supplierlocal);
                _context.SaveChanges();

            }
        }

        public async Task DeleteSupplier(int id)
        {
            var supplierlocal = await _context.Suppliers.FindAsync(id);
            if (supplierlocal != null)
            {
                _context.Suppliers.Remove(supplierlocal);
                _context.SaveChanges();
            }
        }
    }
}
