using FreeExp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    public class CenterController : Controller
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

        public ActionResult Add(Center center)
        {
            Context.Centers.Add(center);
            Context.SaveChanges();
            return View("");
        }

        public ActionResult GetAll()
        {
            IEnumerable<Center> centers = Context.Centers;
            return View(centers);
        }

        public ActionResult Remove(int id)
        {
            Center center = Context.Centers.FirstOrDefault(c => c.Id == id);
            Context.Centers.Remove(center);
            Context.SaveChanges();
            return View();
        }
        
        public ActionResult GetCourses(int centerId)
        {
            IEnumerable<Course> courses = Context.Centers.FirstOrDefault(c => c.Id == centerId).Courses;
            return View("", courses);
        }
    }
}