using System.ComponentModel.DataAnnotations;

namespace SupermarketDB.Models
{
    public class EmailViewModel
    {
        [Required]
        [EmailAddress]
        public string? To { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Body { get; set; }
    }
}
