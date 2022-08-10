using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Services
{
    public class SupplierService : ISupplierService
    {
        // Dependencies
        private ISupplierRepo _repo;
        private IMapper _mapper;

        public SupplierService(ISupplierRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task AddSupplier(SupplierModel supplier)
        {
            Supplier supplierEntity = _mapper.Map<SupplierModel, Supplier>(supplier);
            await _repo.AddSupplier(supplierEntity);
        }

        public async Task<SupplierModel> GetSupplier(int id)
        {
            Supplier supplierEntity = await _repo.GetSupplier(id);
            SupplierModel model = _mapper.Map<Supplier, SupplierModel>(supplierEntity);
            return model;
        }
        public async Task UpdateSupplier(SupplierModel category)
        {
            Supplier supplierEntity = _mapper.Map<SupplierModel, Supplier>(category);
            await _repo.UpdateSupplier(supplierEntity);
        }

        public async Task DeleteSupplier(int id)
        {
            await _repo.DeleteSupplier(id);
        }

        public bool IsSuppliersEmpty()
        {
            return _repo.IsSuppliersEmpty();
        }
    }
}
