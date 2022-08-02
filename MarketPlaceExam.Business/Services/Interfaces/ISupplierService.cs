using MarketPlaceExam.Business.Model;

namespace MarketPlaceExam.Business.Services.Interfaces
{
    public interface ISupplierService
    {
        Task AddSupplier(SupplierModel supplier);
        Task DeleteSupplier(int id);
        Task<SupplierModel> GetSupplier(int id);
        Task UpdateSupplier(SupplierModel category);
    }
}