using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenter.Models
{
    public class EmployeeModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNo { get; set; }

        [Required]
        public string Salary { get; set; }

        public int DepartmentID { get; set; }
        public int SupervisorID { get; set; }
    }
}