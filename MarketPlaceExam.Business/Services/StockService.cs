using AutoMapper;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Services
{
    public class StockService : IStockService
    {
        // Dependencies
        private IStockRepo _repo;
        private IMapper _mapper;

        public StockService(IStockRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       
      
        public async Task UpdateStock(StockModel stock)
        {
            Stock stockEntity = _mapper.Map<StockModel, Stock>(stock);
            await _repo.UpdateStock(stockEntity);
        }

       

        public bool IsStocksEmpty()
        {
            return _repo.IsStocksEmpty();
        }

        public IQueryable<TModel> GetAllStockProducts<TModel>()
        {
            return _repo.GetAllStockProducts<TModel>();
        }

        public Task AddCategoryToProduct(int productid, CategoryModel category)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFromStockById(int stockid)
        {
            await _repo.DeleteStock(stockid);
        }

        public async Task DeleteFromStockByProductId(int productid)
        {
            await _repo.DeleteStockByProductId(productid);
        }

        public async Task<StockModel> GetFromStockByStockId(int stockid)
        {
            Stock stockEntity = await _repo.GetStock(stockid);
            StockModel model = _mapper.Map<Stock, StockModel>(stockEntity);
            return model;
        }

        public async Task<StockModel> GetFromStockByProductId(int productid)
        {
           Stock stockEntity = await _repo.GetStockByProductId(productid);
           StockModel model = _mapper.Map<Stock, StockModel>(stockEntity);
           return model;
        }

        public async Task<bool> AddPicturePath(int productId, string url)
        {
           return await _repo.AddPicturePath(productId, url);
        }

        public async Task<bool> AddProductToStock(StockModel stock)
        {
            bool result = false;
            if (stock != null)
            {
                Stock stockEntity = _mapper.Map<StockModel, Stock>(stock);
                result = await _repo.AddStock(stockEntity);
            }
            return result; 
        }

        public IQueryable<TModel> GetStockProductByInputAndCategoryName<TModel>(string input, string categoryName)
        {
            return _repo.GetStockProductByInputAndCategoryName<TModel>(input, categoryName);
        }

        public IQueryable<TModel> GetStockProductByInput<TModel>(string input)
        {
            return _repo.GetStockProductByInput<TModel>(input);
        }

        public IQueryable<TModel> GetStockProductsByCategoryName<TModel>(string categoryName)
        {
            return _repo.GetStockProductByCategoryName<TModel>(categoryName);
        }

        public IQueryable<TModel> GetStockProductsByCategoryId<TModel>(int categoryId)
        {
            return _repo.GetStockProductByCategoryId<TModel>(categoryId);
        }
    }
}
