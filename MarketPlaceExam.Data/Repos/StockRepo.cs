using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketPlaceExam.Data.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MarketPlaceExam.Data.Repos
{
    public class StockRepo : IStockRepo
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public StockRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    
        public async Task<bool> AddStock(Stock stock)
        {
            int result = 0;
            if (stock != null)
            {
               await _context.Stocks.AddAsync(stock);
               result = await _context.SaveChangesAsync();
            }
            return result > 0;
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            var stocks = await _context
                .Stocks
                .Include(x =>x.Product).ThenInclude(y=>y.Category)
                .Include(x=>x.Product).ThenInclude(y=>y.Supplier)
                .Include(x=>x.Product).ThenInclude(y=>y.Picture)
                .ToListAsync();
            return stocks;
        }
        
        public async Task<Stock> GetStock(int id)
        {
            return await _context
               .Stocks
                 .Include(x => x.Product).ThenInclude(y => y.Category)
                 .Include(x => x.Product).ThenInclude(z => z.Supplier)
                 .Include(x => x.Product).ThenInclude(p => p.Picture)
                 .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateStock(Stock stock)
        {
            int result = 0;
            if (stock != null)
            {
                _context.Stocks.Update(stock);
                result = await _context.SaveChangesAsync();
            }
            return result > 0;
        }

        public async Task DeleteStock(int id)
        {
            Stock? stocklocal = await _context.Stocks.FindAsync(id);
            if (stocklocal != null)
            {
                _context.Stocks.Remove(stocklocal);
               await _context.SaveChangesAsync();
            }
        }
        public bool IsStocksEmpty()
        {
            return _context.Stocks.Any();
        }

        public async Task<Stock> GetStockByProductId(int productid)
        {
            return await _context
                 .Stocks
                 .Include(x=>x.Product).ThenInclude(y=>y.Category)
                 .Include(x=>x.Product).ThenInclude(z=>z.Supplier)
                 .Include(x=>x.Product).ThenInclude(p=>p.Picture)
                 .SingleOrDefaultAsync(x => x.Product.Id == productid);
                 
        }

        public async Task DeleteStockByProductId(int productid)
        {
            var stock = await GetStockByProductId(productid);
            if(stock != null)
            {
                await DeleteStock(stock.Id);
            }
            
        }

        public IQueryable<TModel> GetAllStockProducts<TModel>()
        {
            var products = _context
                .Products
               .Include(x => x.Category)
               .Include(x => x.Picture)
               .Include(x => x.Supplier);
            var result = products.ProjectTo<TModel>(_mapper.ConfigurationProvider);

            return result;
        }
        public async Task<bool> AddPicturePath(int productId, string url)
        {
            int result = 0;
            var stockEntity = await GetStockByProductId(productId);
            if(stockEntity!=null)
            {
                var picture = new Picture() { Uri = url };
                var currentPicture = stockEntity.Product.Pictures.First();
                stockEntity.Product.Pictures.Remove(currentPicture);
                stockEntity.Product.Pictures.Add(picture);

                result = await _context.SaveChangesAsync();
            }
            
            return result > 0;

        }

        public IQueryable<TModel> GetStockProductByInputAndCategoryName<TModel>(string input, string categoryName)
        {
            var products = _context
                 .Products
                .Include(x => x.Category)
                .Where(x => x.Name!.Contains(input) && x.Category.Name.ToLower() == categoryName.ToLower());
            var result = products.ProjectTo<TModel>(_mapper.ConfigurationProvider);

            return result;
        }

        public IQueryable<TModel> GetStockProductByInput<TModel>(string input)
        {
            var products = _context
               .Products
               .Include(x => x.Category)
               .Include(x => x.Picture)
               .Include(x => x.Supplier)
               .Where(x => x.Name!.Contains(input));
            var result = products.ProjectTo<TModel>(_mapper.ConfigurationProvider);

            return result;
        }

        public IQueryable<TModel> GetStockProductByCategoryName<TModel>(string categoryName)
        {
            var products = _context
               .Products
               .Include(x => x.Category)
               .Where(x => x.Category.Name.ToLower() == categoryName.ToLower());

            var result = products.ProjectTo<TModel>(_mapper.ConfigurationProvider);

            return result;
        }

        public IQueryable<TModel> GetStockProductByCategoryId<TModel>(int categoryId)
        {
            var products = _context
              .Products
              .Include(x => x.Category)
              .Where(x => x.Category.Id == categoryId);

            var result = products.ProjectTo<TModel>(_mapper.ConfigurationProvider);

            return result;
        }
    }
}
