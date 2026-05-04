using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(254)]
        public string? Email { get; set; } = null;
    }
}
