using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCenter.Models;
using DataCenter.Core;

namespace DataCenter.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var userid = Session["userID"].ToString();
            var Employees = db.Employees.Where(x => x.SupervisorID == userid).ToList();
            if (Employees.Count != 0)
            {
                ViewBag.Employees = Employees;
            }
            else
            {
                ViewBag.Employees = null;
            }
            return View();
        }

        public ActionResult Add()
        {
            try
            {
                var db = new ApplicationDbContext();
                var userid = Session["userID"].ToString();
                var Departments = db.Depertments.Where(x => x.userid == userid).ToList();
                if(Departments.Count != 0)
                {
                    ViewBag.Departments = Departments;
                }
                else
                {
                    ViewBag.Departments = null;
                }
                return View();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(EmployeeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = new ApplicationDbContext();
                    var checkExistence = db.Employees.Where(x => x.Email == model.Email).FirstOrDefault();
                    if(checkExistence != null)
                    {
                        ModelState.AddModelError("", "An employee with this email address already exist");
                    } 
                    else
                    {
                        var UserID = Session["userID"].ToString();
                        var newEmployee = new Employee {
                            Firstname = model.Firstname, Lastname = model.Lastname,
                            Email = model.Email, PhoneNo = model.PhoneNo, Salary = model.Salary,
                            DepartmentID = model.DepartmentID, SupervisorID = UserID
                        };

                        db.Employees.Add(newEmployee);
                        db.SaveChanges();

                        ViewBag.success = true;
                        ViewBag.Message = "New employee has been successfully added";

                        var Departments = db.Depertments.Where(x => x.userid == UserID).ToList();
                        if (Departments.Count != 0)
                        {
                            ViewBag.Departments = Departments;
                        }
                        else
                        {
                            ViewBag.Departments = null;
                        }

                    }

                    return View(model);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }


        public ActionResult Edit(int emp)
        {
            var db = new ApplicationDbContext();

            var Employee = db.Employees.FirstOrDefault(x => x.ID == emp);
            if(Employee != null)
            {
                var UserID = Session["userID"].ToString();
                ViewBag.Employee = Employee;
                var Departments = db.Depertments.Where(x => x.userid == UserID).ToList();
                if (Departments.Count != 0)
                {
                    ViewBag.Departments = Departments;
                }
                else
                {
                    ViewBag.Departments = null;
                }
            } 
            else
            {
                ViewBag.Employee = null;
            }

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel model, int emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = new ApplicationDbContext();
                    var employee = db.Employees.FirstOrDefault(x => x.ID == emp);
                    if (employee != null)
                    {
                        var UserID = Session["userID"].ToString();

                        employee.Firstname = model.Firstname;
                        employee.Lastname = model.Lastname;
                        employee.Email = model.Email;
                        employee.PhoneNo = model.PhoneNo;
                        employee.Salary = model.Salary;
                        employee.DepartmentID = model.DepartmentID;

                        db.SaveChanges();

                        ViewBag.Employee = employee;

                        ViewBag.success = true;
                        ViewBag.Message = "Employee information updated successfully";

                        var Departments = db.Depertments.Where(x => x.userid == UserID).ToList();
                        if (Departments.Count != 0)
                        {
                            ViewBag.Departments = Departments;
                        }
                        else
                        {
                            ViewBag.Departments = null;
                        }
                       
                    }
                    else
                    {
                        ModelState.AddModelError("", "Employee does not exist in database");
                    }

                    return View(model);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var db = new ApplicationDbContext();

            var Employee = db.Employees.FirstOrDefault(x => x.ID == id);
            if(Employee != null)
            {
                ViewBag.Employee = Employee;
            }
            else
            {
                ViewBag.Employee = null;
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var db = new ApplicationDbContext();
            var userid = Session["userID"].ToString();

            if (id != 0)
            {
                var Employee = db.Employees.FirstOrDefault(x => x.ID == id);
                db.Employees.Remove(Employee);
                db.SaveChanges();

            }

             return RedirectToAction("Index");

        }
    }
}