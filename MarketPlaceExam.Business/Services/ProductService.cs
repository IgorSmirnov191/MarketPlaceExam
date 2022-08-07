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
        private IMapper _mapper;

        public ProductService(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // TODO: Put AutoMapperConfigs in their own config file (Google Automapper Profile class)
        // TODO: ONLY IF ENOUGH TIME -> Veel duplicate code -> Generieke class?
        public async Task AddProduct(ProductModel product)
        {
            var productEntity = _mapper.Map<ProductModel, Product>(product);
            await _repo.AddProduct(productEntity);
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            Product productEntity = await _repo.GetProduct(id);
            var model = _mapper.Map<Product, ProductModel>(productEntity);
            return model;
        }
        public async Task UpdateProduct(ProductModel product)
        {
            var productEntity = _mapper.Map<ProductModel, Product>(product);
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
