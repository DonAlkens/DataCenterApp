using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataCenter.Models;

namespace DataCenter.Core
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string DepartmentName { get; set; }

        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}