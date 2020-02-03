using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataCenter.Models;

namespace DataCenter.Core
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Salary { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department department { get; set; }

        public string SupervisorID { get; set; }
        public virtual ApplicationUser supervisor { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}