using FreeExp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    [RoutePrefix("Course")]
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
            List<Course> courses = Context.Courses.OrderByDescending(x => x.Students.Count).ToList();
            return View("", courses);
        }
        [Route("")]
        //[Authorize(Roles = "Instructor")]
        public ActionResult Create()
        {
            List<Department> departments = Context.Departments.ToList();
            ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "Instructor")]
        public ActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var file = Request.Files[i];
                        string timestamp = DateTime.Now.ToString("dd-MM-yyyy_HHmmss");
                        var fnwithoutex = Path.GetFileNameWithoutExtension(file.FileName);
                        var ex = Path.GetExtension(file.FileName);
                        fileName = fnwithoutex + timestamp + ex;
                        var path = Path.Combine(Server.MapPath("~/Content/PhotosUrl/"), fileName);

                        file.SaveAs(path);
                    }
                }
                Course cou = new Course();
                cou.Name = course.Name;
                cou.Description = course.Description;
                cou.Duration = course.Duration;
                cou.Lectures = course.Lectures;
                //cou.LastUpdateOn = DateTime.Now;
                cou.Requirments = course.Requirments;
                cou.InstrucotrId = course.InstrucotrId;
                cou.DepartmentId = course.DepartmentId;
                cou.PhotoUrl = fileName;
                Context.Courses.Add(course);
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return null;
        }

        //public ActionResult Search(string courseName)
        //{
        //    List<Course> courses = Context.Courses.Where(c => c.Name == courseName).ToList();
        //    return Json(courses);
        //}       
        [Route("Course/{id}/{*title}")]
        public ActionResult Edit(int id)
        {
            var course = Context.Courses.FirstOrDefault(q => q.Id == id);
            var currentuser = User.Identity.GetUserId();
            ViewBag.CurrentCourseId = id; 
            ViewBag.CurrentUserId = User.Identity.GetUserId();
            ViewBag.ALreadyEnrolled = Context.StudentCourses.Where(x => x.StudentId == currentuser)
                .Where(x => x.CourseId == id).FirstOrDefault();
            ViewBag.Rated5Stars = Context.RatingAndReviews.Where(x => x.Rating == 5).Count();
            ViewBag.Rated4Stars = Context.RatingAndReviews.Where(x => x.Rating == 4).Count();
            ViewBag.Rated3Stars = Context.RatingAndReviews.Where(x => x.Rating == 3).Count();
            ViewBag.Rated2Stars = Context.RatingAndReviews.Where(x => x.Rating == 2).Count();
            ViewBag.Rated1Stars = Context.RatingAndReviews.Where(x => x.Rating == 1).Count();
            ViewBag.AvgRate = CalRate(ViewBag.Rated5Stars, ViewBag.Rated4Stars, ViewBag.Rated3Stars, ViewBag.Rated2Stars, ViewBag.Rated1Stars);
            return View("CourseDetails", course);
        }
        [HttpPost]
        [Authorize(Roles = "Instructor")]

        public ActionResult Edit(Course course)
        {
            string fileName = "";
            if (Request.Files.Count < 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    var file = Request.Files[0];
                    string timestamp = DateTime.Now.ToString("dd-MM-yyyy_HHmmss");
                    var fnwithoutex = Path.GetFileNameWithoutExtension(file.FileName);
                    var ex = Path.GetExtension(file.FileName);
                    fileName = fnwithoutex + timestamp + ex;
                    var path = Path.Combine(Server.MapPath("~/Content/PhotosUrl/"), fileName);

                    file.SaveAs(path);
                }
            }
            Course cou = new Course();
            cou.Name = course.Name;
            cou.Description = course.Description;
            cou.Duration = course.Duration;
            cou.Lectures = course.Lectures;
            cou.LastUpdateOn = DateTime.Now;
            cou.Requirments = course.Requirments;
            cou.InstrucotrId = course.InstrucotrId;
            cou.DepartmentId = course.DepartmentId;
            cou.PhotoUrl = fileName;
            Context.Entry(cou).State = EntityState.Modified;
            Context.SaveChanges();
            return View("");
        }
        [Authorize(Roles = "Instructor")]

        public ActionResult Remove(int id)
        {
            Course course = Context.Courses.FirstOrDefault(c => c.Id == id);
            Context.Courses.Remove(course);
            Context.SaveChanges();
            return View("");
        }
        public double CalRate(int star5 , int star4 , int star3 , int star2 , int star1)
        {
            double result = (5 * star5 + 4 * star4 + 3 * star3 + 2 * star2 + 1 * star1) / (star5 + star4 + star3 + star2 + star1);
            var roundedB = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            return roundedB;
        }
    }
}