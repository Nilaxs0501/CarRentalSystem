using CarRentalSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CarName { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public FuelType FuelType { get; set; }
        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Seats must be between 1 and 20.")]

        public int  seats { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Daily rate must be greater than 0")]
        public int DailyRate { get; set; }
          
        [Required]

        public string IsAvailable { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2,3}[-\s]?[A-Z]{0,2}[-\s]?\d{4}$",
        ErrorMessage = "Invalid registration number format. Example: WP CA-1234 or CP-1234.")]

        public string RegistrationNumber { get; set; }

        [Required]
        public string FuelCapacity { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\-\/]+$",
        ErrorMessage = "Insurance policy number can only contain letters, numbers, dashes , and slashes ")]
        public string InsurancePolicyNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string InsuranceExpiryDate { get; set; }

        [Required]
        public  string Descriptioon { get; set; }


    }
}
