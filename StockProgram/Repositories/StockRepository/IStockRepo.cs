using StockProgram.Data;
using StockProgram.Models;

namespace StockProgram.Repositories.StockRepository
{
    public interface IStockRepo
    {
       Task<List<Stock>> GetStocksAsync();
        Task<Stock> GetStock(int id);

        bool AddNewStock(Stock stock); 

        bool DeleteStock(int id);

        bool UpdateStock(Stock stock);

    }
}
