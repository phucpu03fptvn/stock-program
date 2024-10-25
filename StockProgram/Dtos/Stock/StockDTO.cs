﻿using StockProgram_API.Dtos.Comment;
using StockProgram_Domain.Models;

namespace StockProgram.Dtos.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; }

        public string CompanyName { get; set; }

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; }

        public long MarketCap { get; set; }

        public List<CommentDTO> Comments{ get; set; }
    }
}
