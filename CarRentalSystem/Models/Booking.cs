using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Models
{
        public class Booking
        {
            [Key]
            public int BookingID { get; set; }

            [Required]
            public int CarID { get; set; }
            public Car Car { get; set; }

            [Required]
            public Guid CustomerID { get; set; }
            public Customer Customer { get; set; }

            public Guid? AdminID { get; set; }
            public Admin Admin { get; set; }

            [Required]
            public DateTime StartDateTime { get; set; }

            [Required]
            public DateTime EndDateTime { get; set; }

            [Required]
            [Column(TypeName = "decimal(10,2)")]
            public decimal TotalAmount { get; set; }

            [StringLength(20)]
            public string Status { get; set; } = "Pending";

            // Navigation
            public ICollection<Payment> Payments { get; set; }
            
        }
    }



