using StockProgram.Models;

namespace StockProgram.Services.StockService
{
    public interface IStockService
    {
        Task<List<Stock>> GetStocksAsync();

        Task<Stock> GetStockByIdAsync(int id);

        bool CreateStock(Stock stock);

        bool UpdateStock(Stock stock);

        bool DeleteStock(int id);
    }
}
