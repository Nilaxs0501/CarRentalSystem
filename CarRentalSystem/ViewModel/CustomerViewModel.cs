using System.ComponentModel.DataAnnotations;


namespace CarRentalSystem.ViewModel
{
        public class CustomerViewModel
        {
            public Guid CustomerID { get; set; }

            [Required(ErrorMessage = "Name is required.")]
            [StringLength(100)]
            public string Name { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone is required.")]
            [Phone(ErrorMessage = "Invalid phone number.")]
            public string Phone { get; set; }

            [StringLength(200)]
            public string Address { get; set; }

            [Required(ErrorMessage = "NIC is required.")]
            [StringLength(12, ErrorMessage = "NIC cannot exceed 12 characters.")]
            public string NIC { get; set; }

            [Required(ErrorMessage = "License number is required.")]
            [StringLength(20)]
            public string LicenseNo { get; set; }
        }
    }


