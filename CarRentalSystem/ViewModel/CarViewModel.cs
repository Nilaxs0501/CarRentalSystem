using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModel
{
        public class CarViewModel
        {
            public int CarID { get; set; }

            [Required(ErrorMessage = "Car name is required.")]
            [StringLength(100, ErrorMessage = "Car name can't exceed 100 characters.")]
            public string CarName { get; set; }

            [Required(ErrorMessage = "Model is required.")]
            [StringLength(50)]
            public string Model { get; set; }

            [Required(ErrorMessage = "Fuel type is required.")]
            public string FuelType { get; set; }

            [Required(ErrorMessage = "Transmission type is required.")]
            public string Transmission { get; set; }

            [StringLength(500)]
            public string Description { get; set; }

            [Required(ErrorMessage = "Seats number is required.")]
            [Range(1, 20, ErrorMessage = "Seats must be between 1 and 20.")]
            public int Seats { get; set; }

            [Required(ErrorMessage = "Daily rate is required.")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Daily rate must be greater than 0.")]
            public decimal DailyRate { get; set; }

            public bool IsAvailable { get; set; } = true;

            [StringLength(20)]
            public string Color { get; set; }

            [StringLength(50)]
            public string RegistrationNumber { get; set; }

            [Range(0, 1000)]
            public int FuelCapacity { get; set; }

            [StringLength(50)]
            public string InsurancePolicyNo { get; set; }

            [DataType(DataType.Date)]
            public DateTime? InsuranceExpiryDate { get; set; }

            public string LogoFileName { get; set; }
        
            public string CarImageFileName { get; set; }
    }
    }



