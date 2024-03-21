using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models;



namespace Task.Controllers
{
    public class DepartmentController : Controller
    {
        Datacontext db=new Datacontext();
        // GET: Department
        //public ActionResult DepartmentIndex(string searchString,int? filterId)
        //{
           
        //}
        public ActionResult DepartmentIndex(string searchString, int? filterId)
        {
            var departments = db.departments.AsQueryable();
            if (filterId.HasValue)
            {
                departments = departments.Where(model=> model.Department_Id == filterId.Value);
               
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(model => model.Name.Contains(searchString));
            }
            var departmentIds = db.departments.Select(model => model.Department_Id).Distinct();
            ViewBag.DepartmentIdList = new SelectList(departmentIds);
           
            return View(departments.ToList());
        }
        [HttpGet]

        public ActionResult Create()
        {
            Department departments = new Department();
            departments = db.departments.Add(departments);
            return View(departments);
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                db.departments.Add(department);
                db.SaveChanges();
                Response.Redirect("DepartmentIndex");
            }
            return View();
        }
        [HttpGet]

        public ActionResult Edit(int Id)
        {
            Department dep=new Department();
            dep = db.departments.Find(Id);
            return View(dep);
        }
        [HttpPost]
        public ActionResult Edit(Department dep)
        {
            db.Entry(dep).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DepartmentIndex");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Department dep = new Department();
            dep = db.departments.Find(Id);
            return View(dep);
        }
        [HttpPost]
        [ActionName("Delete")]

        public ActionResult postDelete(int Id)
        {
            Department dep = db.departments.Find(Id);
            db.departments.Remove(dep);
            db.SaveChanges();
            return RedirectToAction("DepartmentIndex");
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            Department dep=db.departments.Find(Id);
            return View(dep);
        }
    }
}