using StockProgram.Data;
using StockProgram.Models;

namespace StockProgram.Repositories.StockRepository
{
    public interface IStockRepo
    {
        Task<List<Stock>> GetStocksAsync();
        Task<Stock> GetStock(int id);

        Task<bool> AddNewStock(Stock stock); 

        Task<bool> DeleteStock(int id);

        Task<bool> UpdateStock(Stock stock);

    }
}
