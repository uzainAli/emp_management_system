using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpSys.Models;

namespace EmpSys.ViewModel
{
    public class EmployeeIndexViewModel
    {
        public IEnumerable<Employee> Employee { get; set; }
        public string SearchTerm { get; set; }
    }
}