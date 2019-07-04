using FreeExp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    public class QandAController : Controller
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

        public ActionResult AddQuestion(QandA qandA)
        {

            var user = Context.Users.FirstOrDefault(u => u.Id == qandA.UserOwnerId);

            Course course;
            if (user is Student)
            {
                Student student = (Student)user;
               course = student.Courses.FirstOrDefault(c => c.Id == qandA.CourseId); 
            }
            else
            {
                Instructor instructor = (Instructor)user;
                course = instructor.Courses.FirstOrDefault(c => c.Id == qandA.CourseId);
            }

            QandA qanda = new QandA();
            if(course != null)
            {
                qanda.AskedAt = DateTime.Now;
                qanda.QuestionContent = qandA.QuestionContent;
                qanda.UserOwnerId = qanda.UserOwnerId;
                qanda.CourseId = qandA.CourseId;
            Context.QandAs.Add(qanda);
            Context.SaveChanges();
            }
            return View("");
        }

        public ActionResult AddAnswer(PracticeQandAs answer)
        {
            QandA qandA = Context.QandAs.FirstOrDefault(q => q.Id == answer.QandAId);
            var user = qandA.User;

            Course course;
            if (user is Student)
            {
                Student student = (Student)user;
                course = student.Courses.FirstOrDefault(c => c.Id == qandA.CourseId);
            }
            else
            {
                Instructor instructor = (Instructor)user;
                course = instructor.Courses.FirstOrDefault(c => c.Id == qandA.CourseId);
            }
            if (course != null)
            {
                Context.PracticeQandAs.Add(answer);
                Context.SaveChanges();
            }
            return View("");
        }

        public ActionResult GetQuestions(int courseId)
        {
            List<QandA> qandAs = Context.QandAs.Where(c => c.CourseId == courseId).ToList();
            return View("", qandAs);
        }

    }
}