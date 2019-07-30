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

        //[Authorize(Roles = "Student")]
        public ActionResult Add(RatingAndReview ratingAndReview)
        {
            RatingAndReview rating = new RatingAndReview();
            rating.CourseId = ratingAndReview.CourseId;
            rating.Rating = ratingAndReview.Rating;
            rating.StudentId = ratingAndReview.StudentId;
            Context.RatingAndReviews.Add(rating);
            Context.SaveChanges();
            return Json("Ok");
        }

        public ActionResult Rating()
        {
            return PartialView();
        }
    }
}