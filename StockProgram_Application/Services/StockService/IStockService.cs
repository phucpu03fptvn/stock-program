using StockProgram_Application.Helpers;
using StockProgram_Domain.Models;

namespace StockProgram.Services.StockService
{
    public interface IStockService
    {
        Task<List<Stock>> GetStocksAsync(QueryObject query);

        Task<Stock> GetStockByIdAsync(int id);

        Task<bool> CreateStock(Stock stock);

        Task<bool> UpdateStock(Stock stock);

        Task<bool> DeleteStock(int id);
    }
}
