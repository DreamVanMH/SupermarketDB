using System.ComponentModel.DataAnnotations;

namespace SupermarketDB.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }
    }
}
