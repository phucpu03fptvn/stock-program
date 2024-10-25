using System.ComponentModel.DataAnnotations;

namespace StockProgram_API.Dtos.Account
{
    public class RegisterDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        [EmailAddress]
        public string emailAddress { get; set; }

        [Required]
        public string password { get; set; }
    }
}
