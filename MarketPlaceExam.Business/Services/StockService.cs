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

        public StockService(IStockRepo repo)
        {
            _repo = repo;
        }

        // TODO: Perform mappings using Automapper instead of manually.
        // TODO: CRUD.
        public async Task AddStock(StockModel stock)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StockModel, Stock>());
            var mapper = new Mapper(config);
            var stockEntity = mapper.Map<StockModel, Stock>(stock);
            await _repo.AddStock(stockEntity);
        }

        public async Task<StockModel> GetStock(int id)
        {
            Stock stockEntity = await _repo.GetStock(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Stock, StockModel>());
            var mapper = new Mapper(config);
            var model = mapper.Map<Stock, StockModel>(stockEntity);
            return model;
        }
        public async Task UpdateStock(StockModel stock)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StockModel, Stock>());
            var mapper = new Mapper(config);
            var stockEntity = mapper.Map<StockModel, Stock>(stock);
            await _repo.UpdateStock(stockEntity);
        }

        public async Task DeleteStock(int id)
        {
            await _repo.DeleteStock(id);
        }
    }
}
