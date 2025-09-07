
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRentalSystem.Attribute;
namespace CarRentalSystem.Models
{
    public class Admin
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Admin name is required.")]
        [Display(Name = "Administrator Name")]

        public  string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [CustomEmailAttribute]
        public string Email { get; set; }

        [CustomPasswordAttribute]
        public string Password { get; set; } 


    }
}
