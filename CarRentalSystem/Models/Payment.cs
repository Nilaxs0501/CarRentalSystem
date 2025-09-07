using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{

        public class Payment
        {
            [Key]
            public int PaymentID { get; set; }

            [Required]
            public int BookingID { get; set; }
            public Booking Booking { get; set; }

            [Required]
            public DateTime PaymentDate { get; set; }

            [Required]
            [StringLength(50)]
            public string PaymentMethod { get; set; }

            [Required]
            [StringLength(20)]
            public string PaymentStatus { get; set; } = "Pending";
        }
    }


