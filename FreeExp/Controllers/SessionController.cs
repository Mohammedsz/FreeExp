using FreeExp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    [RoutePrefix("Session")]
    public class SessionController : Controller
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

        [Authorize(Roles = "Instructor")]
        public ActionResult Create()
        {
            ViewBag.courses = Context.Courses.ToList();

            return View();
        }

        [Authorize(Roles = "Instructor")]
        public ActionResult Add(CourseSession session)
        {
            Context.CourseSessions.Add(session);
            Context.SaveChanges();
            return View("");
        }

        public ActionResult GetAll(int courseId)
        {
            List<CourseSession> sessions = Context.Courses.FirstOrDefault(c => c.Id == courseId).CourseSessions.ToList();
            return Json(sessions);
        }
        [Authorize(Roles = "Instructor")]
        public ActionResult Edit(CourseSession session)
        {
            CourseSession oldSession = Context.CourseSessions.FirstOrDefault(s => s.Id == session.Id);
            oldSession.Name = session.Name;
            oldSession.SessionDate = session.SessionDate;
            oldSession.StartFrom = session.StartFrom;
            oldSession.VideoUrl = session.VideoUrl;
            oldSession.YouTubeIFrame = session.YouTubeIFrame;
            oldSession.EndAt = session.EndAt;
            oldSession.Duration = session.Duration;
            oldSession.Description = session.Description;
            oldSession.Address = session.Address;
            Context.Entry<CourseSession>(oldSession).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return View("");
        }
    }
}