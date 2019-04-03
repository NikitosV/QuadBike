using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuadBike.Model.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="PhoneNumber")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Not correct")]
        [DataType(DataType.Password)]
        [Display(Name = "Access password")]
        public string PasswordConfirm { get; set; }
    }
}
