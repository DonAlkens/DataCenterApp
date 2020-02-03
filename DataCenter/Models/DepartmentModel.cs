using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCenter.Models
{
    public class DepartmentModel
    {
        [Required(ErrorMessage ="Please enter a department name")]
        public string DepartmentName { get; set; }
    }
}