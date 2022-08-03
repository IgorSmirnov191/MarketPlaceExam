using AutoMapper;
using MarketPlaceExam.Data.Entities;
using MarketPlace.MVC.Data;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Repos
{
    public class StockRepo : IStockRepo
    {
        private ApplicationDbContext _context;

        public StockRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStock(Stock stock)
        {
            if (stock != null)
            {
                await _context.Stocks.AddAsync(stock);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetStock(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task UpdateStock(Stock stock)
        {
            if (stock != null)
            {
                _context.Stocks.Update(stock);
                _context.SaveChanges();
            }
        }

        public async Task DeleteStock(int id)
        {
            var stocklocal = await _context.Stocks.FindAsync(id);
            if (stocklocal != null)
            {
                _context.Stocks.Remove(stocklocal);
                _context.SaveChanges();
            }
        }
        public bool IsStocksEmpty()
        {
            return _context.Stocks.Any();
        } 
    }
}
