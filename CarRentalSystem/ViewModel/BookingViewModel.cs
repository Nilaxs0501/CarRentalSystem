using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModel
{
  
        public class BookingViewModel
        {
            public int BookingID { get; set; }

            [Required(ErrorMessage = "Car selection is required.")]
            public int CarID { get; set; }

            [Required(ErrorMessage = "Customer is required.")]
            public Guid CustomerID { get; set; }

            [DataType(DataType.DateTime)]
            [Required(ErrorMessage = "Start date and time is required.")]
            public DateTime StartDateTime { get; set; }

            [DataType(DataType.DateTime)]
            [Required(ErrorMessage = "End date and time is required.")]
            public DateTime EndDateTime { get; set; }

            [Required]
            [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
            public decimal TotalAmount { get; set; }

            public string Status { get; set; } = "Pending";
        }
    }



