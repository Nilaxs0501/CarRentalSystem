using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    
        public class Admin
        {
            [Key]
            public Guid AdminID { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            // Navigation
            public ICollection<Booking> Bookings { get; set; }
        }
    }




