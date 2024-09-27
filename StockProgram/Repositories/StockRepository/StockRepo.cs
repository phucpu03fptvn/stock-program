using Microsoft.EntityFrameworkCore;
using StockProgram.Data;
using StockProgram.Models;

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
            var stock =  await _dbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            return stock;

        }

        public async Task<List<Stock>> GetStocksAsync() =>await _dbContext.Stocks.ToListAsync();
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
