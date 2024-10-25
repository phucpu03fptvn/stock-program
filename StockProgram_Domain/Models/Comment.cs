using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockProgram_Domain.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? StockId { get; set; }

        public Stock? Stock { get; set; }
    }
}
