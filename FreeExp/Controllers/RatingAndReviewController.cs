using FreeExp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace FreeExp.Controllers
{
    public class RatingAndReviewController : Controller
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

        [Authorize(Roles = "Student")]
        public ActionResult Add([FromBody]int courseId, [FromBody]int rating)
        {
            string userId = User.Identity.GetUserId();
            if (Context.StudentCourses.Where(x => x.StudentId == userId)
                .Where(x => x.CourseId == courseId).Any())
            {
                RatingAndReview ratingAndReview = new RatingAndReview
                {
                    StudentId = userId,
                    CourseId = courseId,
                    Rating = rating
                };
                Context.RatingAndReviews.Add(ratingAndReview);
                Context.SaveChanges();
            }
            return new EmptyResult();
        }

        public ActionResult Rating()
        {
            return PartialView();
        }
    }
}