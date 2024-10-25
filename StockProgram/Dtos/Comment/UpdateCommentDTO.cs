using System.ComponentModel.DataAnnotations;

namespace StockProgram_API.Dtos.Comment
{
    public class UpdateCommentDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(500, ErrorMessage = "Content can't be longer than 500 characters.")]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "StockId must be greater than 0.")]
        public int? StockId { get; set; }
    }
}
