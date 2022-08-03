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
    public class ProductService : IProductService
    {
        // Dependencies
        private IProductRepo _repo;

        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddProduct(ProductModel product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductModel, Product>());
            var mapper = new Mapper(config);
            var productEntity = mapper.Map<ProductModel, Product>(product);
            await _repo.AddProduct(productEntity);
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            Product productEntity = await _repo.GetProduct(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Product, ProductModel>(productEntity);
            return model;
        }
        public async Task UpdateProduct(ProductModel product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductModel, Product>());
            var mapper = new Mapper(config);
            var productEntity = mapper.Map<ProductModel, Product>(product);
            await _repo.UpdateProduct(productEntity);
        }

        public async Task DeleteProduct(int id)
        {
            await _repo.DeleteProduct(id);
        }

        public bool IsProductsEmpty()
        {
            return _repo.IsProductsEmpty();
        }
    }
}
