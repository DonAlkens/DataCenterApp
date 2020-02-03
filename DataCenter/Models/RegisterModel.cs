using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenter.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}