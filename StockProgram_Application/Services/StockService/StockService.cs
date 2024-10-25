using StockProgram.Repositories.StockRepository;
using StockProgram_Application.Helpers;
using StockProgram_Domain.Models;

namespace StockProgram.Services.StockService
{
    public class StockService : IStockService
    {
        private IStockRepo _stockRepo;
        public StockService(IStockRepo stockRepo)
        {
            _stockRepo = stockRepo;
        }
        public async Task<bool> CreateStock(Stock stock)
        {
            try
            {
                await _stockRepo.AddNewStock(stock);
                return true;    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteStock(int id)
        {
            bool result = false;
            try
            {
                await _stockRepo.DeleteStock(id);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<Stock> GetStockByIdAsync(int id)=> await _stockRepo.GetStock(id);

        public async Task<List<Stock>> GetStocksAsync(QueryObject query)=> await _stockRepo.GetStocksAsync(query);

        public async Task<bool> UpdateStock(Stock stock)
        {
            bool result = false;
            try
            {
               await _stockRepo.UpdateStock(stock);
                result=true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
