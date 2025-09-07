using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.ViewModel
{
        public class RegisterViewModel
        {
            [Required(ErrorMessage = "Name is required.")]
            [StringLength(100)]
            public string Name { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone is required.")]
            [Phone(ErrorMessage = "Invalid phone number.")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm password is required.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }



