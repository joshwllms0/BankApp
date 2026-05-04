using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0.01, 999.99)]
        public decimal Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
