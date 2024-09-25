using StockProgram.Models;
using StockProgram.Repositories.StockRepository;

namespace StockProgram.Services.StockService
{
    public class StockService : IStockService
    {
        private IStockRepo _stockRepo;
        public StockService(IStockRepo stockRepo)
        {
            _stockRepo = stockRepo;
        }
        public bool CreateStock(Stock stock)
        {
            bool result = false;
            try
            {
                _stockRepo.AddNewStock(stock);
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
                _stockRepo.DeleteStock(id);
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Task<Stock> GetStockByIdAsync(int id)=> _stockRepo.GetStock(id);

        public Task<List<Stock>> GetStocksAsync()=> _stockRepo.GetStocksAsync();

        public bool UpdateStock(Stock stock)
        {
            bool result = false;
            try
            {
                _stockRepo.UpdateStock(stock);
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
