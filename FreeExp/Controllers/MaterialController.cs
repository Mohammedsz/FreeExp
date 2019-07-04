using FreeExp.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeExp.Controllers
{
    public class MaterialController : Controller
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
        public ActionResult Add(CourseMaterial material)
        {
            //material.File = wrapper.
            if(Request.Files.Count >0)
            {

            }
            return View();
        }


    }
}