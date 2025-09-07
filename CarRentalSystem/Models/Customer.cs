using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Customer
    {
            [Key]
            public Guid CustomerID { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Phone]
            public string Phone { get; set; }

            [StringLength(200)]
            public string Address { get; set; }

            [Required]
            [StringLength(12)]
            public string NIC { get; set; }

            [Required]
            [StringLength(20)]
            public string LicenseNo { get; set; }

            // Navigation
            public ICollection<Booking> Bookings { get; set; }
            public ICollection<Feedback> Feedbacks { get; set; }
    }
    }



