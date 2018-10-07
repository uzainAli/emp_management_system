using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpSys.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Number { get; set; }

    }
}