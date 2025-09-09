using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModel
{
        public class FeedbackViewModel
        {
            public int FeedbackID { get; set; }

            [Required(ErrorMessage = "Booking is required.")]
            public int BookingID { get; set; }

            [Required(ErrorMessage = "Customer is required.")]
            public Guid CustomerID { get; set; }

            [Required(ErrorMessage = "Car is required.")]
            public int CarID { get; set; }

            [Required(ErrorMessage = "Feedback text is required.")]
            [StringLength(500, ErrorMessage = "Feedback can't exceed 500 characters.")]
            public string FeedbackText { get; set; }
        }
    }



