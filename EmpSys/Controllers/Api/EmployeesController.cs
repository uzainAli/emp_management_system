using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmpSys.Models;

namespace EmpSys.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
                _context=new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            var employee=_context.Employees.ToList();
            return Ok(employee);
        }
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
           var employee= _context.Employees.Include(e => e.Contact).Single(e => e.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }
    }
}
