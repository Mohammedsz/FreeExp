using FreeExp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicationDbContext Context
        {
            get
            {
                return _context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            set { _context = value; }
        }

        public ActionResult Add(Department department)
        {
            Context.Departments.Add(department);
            Context.SaveChanges();
            return View("");
        }

        public ActionResult GetAll()
        {
            IEnumerable<Department> departments = Context.Departments;
            return View(departments);
        }

        public ActionResult Remove(int id)
        {
            Department department = Context.Departments.FirstOrDefault(d => d.Id == id);
            Context.Departments.Remove(department);
            Context.SaveChanges();
            return View();
        }

        public ActionResult GetCourses(int departmentId)
        {
            IEnumerable<Course> courses = Context.Departments.FirstOrDefault(d => d.Id == departmentId).Courses;
            return View(courses);
        }
    }
}