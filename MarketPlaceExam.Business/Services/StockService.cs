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
        public async Task AddStock(StockModel stock)
        {
            Stock stockEntity = _mapper.Map<StockModel, Stock>(stock);
            await _repo.AddStock(stockEntity);
        }

        public async Task<StockModel> GetStock(int id)
        {
            Stock stockEntity = await _repo.GetStock(id);
            StockModel model = _mapper.Map<Stock, StockModel>(stockEntity);
            return model;
        }
        public async Task UpdateStock(StockModel stock)
        {
            Stock stockEntity = _mapper.Map<StockModel, Stock>(stock);
            await _repo.UpdateStock(stockEntity);
        }

        public async Task DeleteStock(int id)
        {
            await _repo.DeleteStock(id);
        }

        public bool IsStocksEmpty()
        {
            return _repo.IsStocksEmpty();
        }
    }
}
