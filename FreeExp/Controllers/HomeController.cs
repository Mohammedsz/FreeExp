using FreeExp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult BusinessCourses()
        {
            var businesscourses = db.Courses.Where(x => x.DepartmentId == 1).
                 OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_BusinessCourses", businesscourses);
        }
        [ChildActionOnly]
        public ActionResult LanguagesCourses()
        {
            var langcourses = db.Courses.Where(x => x.DepartmentId == 2).
                OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_LanguagesCourses", langcourses);
        }
        [ChildActionOnly]
        public ActionResult ITCourses()
        {
            var softcourses = db.Courses.Where(x => x.DepartmentId == 3).
                OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_SoftwareCourses", softcourses);
        }
        [ChildActionOnly]
        public ActionResult EngineeringCourses()
        {
            var engcourses = db.Courses.Where(x => x.DepartmentId == 4).
                OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_EngineeringCourses", engcourses);
        }
        [ChildActionOnly]
        public ActionResult MarktingCourses()
        {
            var marktingcourses = db.Courses.Where(x => x.DepartmentId == 5).
                OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_MarktingCourses", marktingcourses);
        }
        [ChildActionOnly]
        public ActionResult ManagmentCourses()
        {
            var managmentcourses = db.Courses.Where(x => x.DepartmentId == 6).
                OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_ManagmentCourses", managmentcourses);
        }
        [ChildActionOnly]
        public ActionResult MediaCourses()
        {
            var mediacourses = db.Courses.Where(x => x.DepartmentId == 6).
                OrderByDescending(x => x.Students.Count()).Take(12).ToList();
            return PartialView("_MediaCourses", mediacourses);
        }
        public ActionResult GetAllCoursesAuto()
        {
            var all = db.Courses.Select(x => x.Name).ToList();
            return Json(all, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}