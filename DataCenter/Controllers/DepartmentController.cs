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
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var userid = Session["userID"].ToString();
            var Departments = db.Depertments.Where(x => x.userid == userid).ToList();
            if (Departments.Count != 0)
            {
                ViewBag.Departments = Departments;
            }
            else
            {
                ViewBag.Departments = null;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                } 
                else
                {
                    var db = new ApplicationDbContext();
                    // Check Department name existence
                    var UserID = Session["userID"].ToString();
                    var check = db.Depertments.FirstOrDefault(x => x.DepartmentName == model.DepartmentName);

                    if(check != null)
                    {
                        ModelState.AddModelError("","This department already exist. Please enter a new department name");
                    }
                    else
                    {
                        var Department = new Department()
                        {
                            DepartmentName = model.DepartmentName,
                            userid = UserID
                        };

                        db.Depertments.Add(Department);
                        db.SaveChanges();

                        ViewBag.success = true;
                        ViewBag.Message = "New Department Successfully addad";
                    }
                }

                return View(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
        public ActionResult Edit(int emp)
        {
            var db = new ApplicationDbContext();

            var Department = db.Depertments.FirstOrDefault(x => x.ID == emp);
            if (Department != null)
            {
                ViewBag.Department = Department;
            }
            else
            {
                ViewBag.Department = null;
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentModel model, int emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var db = new ApplicationDbContext();
                    var department = db.Depertments.FirstOrDefault(x => x.ID == emp);
                    if(department != null)
                    {
                        department.DepartmentName = model.DepartmentName;
                        db.SaveChanges();

                        ViewBag.Department = department;

                        ViewBag.success = true;
                        ViewBag.Message = "Department information updated successfully";
                    }
                    else
                    {
                        ModelState.AddModelError("","Department not found!");
                    }


                }

                return View(model);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


        public ActionResult Delete(int id)
        {
            var db = new ApplicationDbContext();
            var userid = Session["userID"].ToString();

            if (id != 0)
            {
                var department = db.Depertments.FirstOrDefault(x => x.ID == id);
                db.Depertments.Remove(department);
                db.SaveChanges();

            }

            return RedirectToAction("Index");

        }
    }
}