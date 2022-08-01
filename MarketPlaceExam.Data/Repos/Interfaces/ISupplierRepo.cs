using MarketPlaceExam.Data.Entities;

namespace MarketPlaceExam.Data.Repos.Interfaces
{
    public interface ISupplierRepo
    {
        Task AddSupplier(Supplier supplier);
        Task DeleteSupplier(int id);
        Task<Supplier> GetSupplier(int id);
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task UpdateSupplier(Supplier supplier);
    }
}