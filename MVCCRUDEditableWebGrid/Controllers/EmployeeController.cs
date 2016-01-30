using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisplayWebGrid.Models;
using System.Web.Helpers;
using System.Data.Entity;

namespace MVCDisplayWebGrid.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBContext db = new EmployeeDBContext();
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = db.Employees.Single(em => em.Id == employee.Id);
                emp.Name = employee.Name;
                emp.Designation = employee.Designation;
                emp.City = employee.City;
                emp.State = employee.State;
                emp.Zip = employee.Zip;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
	}
}