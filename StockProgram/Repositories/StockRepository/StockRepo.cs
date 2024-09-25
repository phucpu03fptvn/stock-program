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
        public bool AddNewStock(Stock stock)
        {
            bool result = false;
            try
            {
                _dbContext.Stocks.Add(stock);
                _dbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool DeleteStock(int id)
        {
            bool result = false;
            try
            {
                var selectedStock = _dbContext.Stocks.FirstOrDefault(x => x.Id == id);
                _dbContext.Stocks.Remove(selectedStock);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Task<Stock> GetStock(int id) => _dbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<Stock>> GetStocksAsync() => _dbContext.Stocks.ToListAsync();
        public bool UpdateStock(Stock stock)
        {
            bool result = false;
            try
            {
                _dbContext.Stocks.Update(stock);
                _dbContext.SaveChangesAsync();
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
