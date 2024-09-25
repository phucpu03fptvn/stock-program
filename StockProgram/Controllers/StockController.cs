using Microsoft.AspNetCore.Mvc;
using StockProgram.Data;
using StockProgram.Dtos.Stock;
using StockProgram.Mappers;
using System.Dynamic;

namespace StockProgram.Controllers
{
    [Route("api/v1")]
    public class StockController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public StockController(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet("/getAllStocks")]
        public IActionResult GetAllStocks()
        {
            var stocks = _dbContext.Stocks.ToList().Select(s => s.ToStockDTO());
            return Ok(stocks);
        }

        [HttpGet("/getStock/{id}")]
        public IActionResult GetStock([FromRoute] int id)
        {
            var stock = _dbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (stock == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy
            }
            return Ok(stock.ToStockDTO());
        }

        [HttpPost("")]

        public IActionResult CreateStock([FromBody] CreateStockRequestDTO stockRequestDTO)
        {
            var stockModel = stockRequestDTO.ToStockFromCreateDTO();
            _dbContext.Stocks.Add(stockModel);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetStock), new { id = stockModel.Id }, stockModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStock([FromRoute] int id, [FromBody] UpdateStockDTO updateStockDTO)
        {
            var stockModel = _dbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (stockModel == null)
            {
                return NotFound();
            }

            stockModel.Symbol = updateStockDTO.Symbol;
            stockModel.CompanyName = updateStockDTO.CompanyName;
            stockModel.Purchase = updateStockDTO.Purchase;
            stockModel.MarketCap = updateStockDTO.MarketCap;
            stockModel.LastDiv = updateStockDTO.LastDiv;
            stockModel.Industry = updateStockDTO.Industry;

            _dbContext.Update(stockModel);
            _dbContext.SaveChanges();
            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock([FromRoute] int id)
        {
            string message = "";
            var stockModel = _dbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (stockModel != null)
            {
                _dbContext.Stocks.Remove(stockModel);
                _dbContext.SaveChanges();
                message = $"DeleteSuccessfully stock with id: {id}";
            }
            else
            {
                message = "Delete fail";
            }
            return Ok(message);
        }
    }
}
