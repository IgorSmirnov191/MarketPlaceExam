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

        public SupplierService(ISupplierRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddSupplier(SupplierModel supplier)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CategoryModel, Category>());
            var mapper = new Mapper(config);
            var supplierEntity = mapper.Map<SupplierModel, Supplier>(supplier);
            await _repo.AddSupplier(supplierEntity);
        }

        public async Task<SupplierModel> GetSupplier(int id)
        {
            Supplier supplierEntity = await _repo.GetSupplier(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Supplier, SupplierModel>(supplierEntity);
            return model;
        }
        public async Task UpdateSupplier(SupplierModel category)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SupplierModel, Supplier>());
            var mapper = new Mapper(config);
            var supplierEntity = mapper.Map<SupplierModel, Supplier>(category);
            await _repo.UpdateSupplier(supplierEntity);
        }

        public async Task DeleteSupplier(int id)
        {
            await _repo.DeleteSupplier(id);
        }
    }
}
