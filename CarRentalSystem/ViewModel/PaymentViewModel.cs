using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModel
{
        public class PaymentViewModel
        {
            public int PaymentID { get; set; }

            [Required(ErrorMessage = "Booking is required.")]
            public int BookingID { get; set; }

            [DataType(DataType.Date)]
            [Required(ErrorMessage = "Payment date is required.")]
            public DateTime PaymentDate { get; set; }

            [Required(ErrorMessage = "Payment method is required.")]
            public string PaymentMethod { get; set; }

            [Required(ErrorMessage = "Payment status is required.")]
            public string PaymentStatus { get; set; } = "Pending";
        }
    }



