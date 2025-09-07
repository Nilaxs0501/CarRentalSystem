using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
        public class Feedback
        {
            [Key]
            public int FeedbackID { get; set; }

            [Required]
            public int BookingID { get; set; }
            public Booking Booking { get; set; }

            [Required]
            public Guid CustomerID { get; set; }
            public Customer Customer { get; set; }

            [Required]
            public int CarID { get; set; }
            public Car Car { get; set; }

            [Required]
            [StringLength(500)]
            public string FeedbackText { get; set; }
        }
    }


