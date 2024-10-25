using StockProgram_Application.Helpers;
using StockProgram_Domain.Models;

namespace StockProgram.Repositories.StockRepository
{
    public interface IStockRepo
    {
        Task<List<Stock>> GetStocksAsync(QueryObject query);
        Task<Stock> GetStock(int id);

        Task<bool> AddNewStock(Stock stock); 

        Task<bool> DeleteStock(int id);

        Task<bool> UpdateStock(Stock stock);

    }
}
