using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;

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

        public async Task AddProduct(ProductModel product)
        {
            Product productEntity = _mapper.Map<ProductModel, Product>(product);
            await _repo.AddProduct(productEntity);
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            Product productEntity = await _repo.GetProduct(id);
            ProductModel model = _mapper.Map<Product, ProductModel>(productEntity);
            return model;
        }
        public async Task UpdateProduct(ProductModel product)
        {
            Product productEntity = _mapper.Map<ProductModel, Product>(product);
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

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            IEnumerable<Product> productEntity =  await _repo.GetProducts();
            IEnumerable<ProductModel> model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(productEntity);
            return model;
            
        }

        public async Task<IEnumerable<ProductModel>> GetProductsBySupplier(int supplierId)
        {
            IEnumerable<Product> productEntity = await _repo.GetProductsBySupplierId(supplierId);
            IEnumerable<ProductModel> model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(productEntity);
            return model;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<Product> productEntity = await _repo.GetProductsByCategoryId(categoryId);
            IEnumerable<ProductModel> model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(productEntity);
            return model;
        }
    }
}
