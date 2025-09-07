
﻿using CarRentalSystem.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalSystem.Models
{
    public class Customer
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [CustomEmailAttribute]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [CustomPasswordAttribute]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(\d{9}[VXvx]|\d{12})$",
        ErrorMessage = "NIC must be either 9 digits followed by 'V' or 'X' (e.g., 123456789V) or 12 digits (e.g., 200012345678).")]
        public string NIC { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}\d{7}$",
        ErrorMessage = "Driving License Number must start with a letter followed by 7 digits (e.g., B1234567).")]
        [Display(Name = "Driving License Number")]
        public string DrivingLicenseNo { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
