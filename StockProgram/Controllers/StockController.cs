using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockProgram.Data;
using StockProgram.Dtos.Stock;
using StockProgram.Mappers;
using StockProgram.Services.StockService;
using System.Dynamic;

namespace StockProgram.Controllers
{
    [Route("api/v1")]
    public class StockController : Controller
    {
        private IStockService _stockService;
        public StockController(IStockService service)
        {
            _stockService = service;
        }

        [HttpGet("/getAllStocks")]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockService.GetStocksAsync();
            var stocksResult = stocks.Select(s => s.ToStockDTO()); 
            return Ok(stocksResult);
        }

        [HttpGet("/getStock/{id}")]
        public async Task<IActionResult> GetStock([FromRoute] int id)
        {
            var stock = await _stockService.GetStockByIdAsync(id);
            if (stock == null) {
                return BadRequest();
            }
            else {
                //Chuyển đổi sang DTO cần phải chắc chắn rằng stock đã được gen đầy đủ 
                var stockDTO = stock.ToStockDTO();
                return Ok(stockDTO);
            }
           
        }

        [HttpPost("")]

        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDTO stockRequestDTO)
        {
            var stockModel = stockRequestDTO.ToStockFromCreateDTO();
            var result = await _stockService.CreateStock(stockModel);

            return CreatedAtAction(nameof(GetStock), new { id = stockModel.Id }, stockModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockDTO updateStockDTO)
        {
            var stockModel = await _stockService.GetStockByIdAsync(id);
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

            var result = await _stockService.UpdateStock(stockModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            string message = "";
            var stockModel = await _stockService.GetStockByIdAsync(id);
            if (stockModel != null)
            {
                await _stockService.DeleteStock(stockModel.Id);
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
