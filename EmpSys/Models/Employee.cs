using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace EmpSys.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Designation { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }  
    }
}