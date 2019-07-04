using FreeExp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    public class CourseController : Controller
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

        public ActionResult GetAll()
        {
            List<Course> courses = Context.Courses.ToList();
            return View("", courses);
        }

        public ActionResult Add(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
            return null;
        }

        public ActionResult Search(string courseName)
        {
            List<Course> courses = Context.Courses.Where(c => c.Name == courseName).ToList();
            return Json(courses);
        }

        public ActionResult Edit(Course course)
        {
            Course oldCourse = Context.Courses.FirstOrDefault(c => c.Id == course.Id);
            oldCourse.Name = course.Name;
            oldCourse.Duration = course.Duration;
            oldCourse.Description = course.Description;
            oldCourse.Lectures = course.Lectures;
            oldCourse.Requirments = course.Requirments;
            oldCourse.LastUpdateOn = course.LastUpdateOn;
            oldCourse.CenterID = course.CenterID;
            Context.Entry<Course>(oldCourse).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return View("");
        }

        public ActionResult Remove(int id)
        {
            Course course = Context.Courses.FirstOrDefault(c => c.Id == id);
            Context.Courses.Remove(course);
            Context.SaveChanges();
            return View("");
        }

    }
}