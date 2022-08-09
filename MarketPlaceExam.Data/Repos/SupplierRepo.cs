using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;

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
            if (supplier != null)
            {
                _context.Suppliers.Update(supplier);
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
        public bool IsSuppliersEmpty()
        {
            return _context.Suppliers.Any();
        } 
    }
}
