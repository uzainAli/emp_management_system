using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpSys.Models;
using System.Data.Entity;
using EmpSys.ViewModel;
using Microsoft.Ajax.Utilities;

namespace EmpSys.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeController()
        {
            _context=new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index(string query=null)
        {
            
         
            if (!String.IsNullOrWhiteSpace(query))
            {
            var employee = _context.Employees.Include(e => e.Contact).
                           Where(e => e.Name.Contains(query) || 
                           e.Designation.Contains(query) ||
                           e.Contact.Number.Contains(query)).ToList();
                var viewModel = new EmployeeIndexViewModel()
                {
                    Employee = employee,
                    SearchTerm = query
                };
                return View(viewModel);
            }
            else
            {
                var employee = _context.Employees.Include(e => e.Contact).ToList();
                var viewModel = new EmployeeIndexViewModel()
                {
                    Employee = employee,
                    SearchTerm = query
                };
                return View(viewModel);
            }
          
        }
        public ActionResult EmployeeForm()
        {
            var employee=new Employee();
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            
                var employee = _context.Employees.Include(e => e.Contact).Single(e => e.Id == id);
                return View("EmployeeForm", employee);
            
           
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View("EmployeeForm", emp);
            }
            if (emp.Id==0)
            {
                var contact = new Contact()
                {
                    Number = emp.Contact.Number
                };
                _context.Contacts.Add(contact);
                var employee = new Employee()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Designation = emp.Designation,
                    ContactId = contact.Id
                };
                _context.Employees.Add(employee);
            }
            else
            {
                var employee = _context.Employees.Include(e => e.Contact).Single(e => e.Id == emp.Id);

                employee.Id = emp.Id;
                employee.Name = emp.Name;
                employee.Designation = emp.Designation;
                employee.Contact.Number = emp.Contact.Number;


            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult Search(EmployeeIndexViewModel viewModel)
        {

            return RedirectToAction("Index", "Employee", new {query = viewModel.SearchTerm});
        }
    }
}