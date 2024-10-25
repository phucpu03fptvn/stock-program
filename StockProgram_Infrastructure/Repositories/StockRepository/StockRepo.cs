using Microsoft.EntityFrameworkCore;
using StockProgram_Application.Helpers;
using StockProgram_Domain.Models;
using StockProgram_Infrastructure.Data;

namespace StockProgram.Repositories.StockRepository
{
    public class StockRepo : IStockRepo
    {
        private ApplicationDBContext _dbContext;

        public StockRepo(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<bool> AddNewStock(Stock stock)
        {
            bool result = false;
            try
            {
                    _dbContext.Stocks.Add(stock);
                    await _dbContext.SaveChangesAsync();
                    result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<bool> DeleteStock(int id)
        {
            bool result = false;
            try
            {
                var selectedStock = await _dbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
                _dbContext.Stocks.Remove(selectedStock);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<Stock> GetStock(int id)
        {
            var stock =  await _dbContext.Stocks.Include(c=> c.Comments).FirstOrDefaultAsync(x => x.Id == id);
            return stock;

        }

        public async Task<List<Stock>> GetStocksAsync(QueryObject query)
        {
            var stocks =  _dbContext.Stocks.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy)) {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol); 
                }
            }
            var skipNumber = (query.PageNumber -1) * query.PageSize;
            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        public async Task<bool> UpdateStock(Stock stock)
        {
            bool result = false;
            try
            {
                _dbContext.Stocks.Update(stock);
                await _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
