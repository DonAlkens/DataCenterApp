using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenter.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email cannot be empty")]
        [EmailAddress(ErrorMessage ="Please enter a valid email addresss")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password Cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}