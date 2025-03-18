using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi
{
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        public DateOnly RegistrationDate { get; set; }
        public Customer() { }
    }
}
