using StockProgram.Models;

namespace StockProgram.Services.StockService
{
    public interface IStockService
    {
        Task<List<Stock>> GetStocksAsync();

        Task<Stock> GetStockByIdAsync(int id);

        Task<bool> CreateStock(Stock stock);

        Task<bool> UpdateStock(Stock stock);

        Task<bool> DeleteStock(int id);
    }
}
