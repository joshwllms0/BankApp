using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        [Required]
        [Range(0.01, 999.99)]
        public decimal Price { get; set; }
    }
}
