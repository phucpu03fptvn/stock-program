using StockProgram.Dtos.Stock;
using StockProgram_API.Mappers;
using StockProgram_Domain.Models;

namespace StockProgram.Mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stockModel)
        {
            try
            {
                return new StockDTO
                {
                    Id = stockModel.Id,
                    Symbol = stockModel.Symbol,
                    CompanyName = stockModel.CompanyName,
                    Purchase = stockModel.Purchase,
                    LastDiv = stockModel.LastDiv,
                    Industry = stockModel.Industry,
                    MarketCap = stockModel.MarketCap,
                    Comments = stockModel.Comments.Select(c => c.ToCommentDTO()).ToList(),
                };
            }
            catch (Exception ex)
            {

                // Ghi log lỗi
                throw new InvalidOperationException("Could not delete stock.", ex);
            }
           
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDTO stockDTO) {
            return new Stock
            {
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purchase = stockDTO.Purchase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap
            };
        }

    }
}
