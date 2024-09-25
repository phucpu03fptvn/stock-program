﻿namespace StockProgram.Dtos.Stock
{
    public class CreateStockRequestDTO
    {
        public string Symbol { get; set; }

        public string CompanyName { get; set; }

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; }

        public long MarketCap { get; set; }

    }
}
