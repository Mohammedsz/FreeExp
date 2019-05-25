using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class CourseSessionAttendance
    {
        public int Id { get; set; }
        public int CourseSessionId { get; set; }
        public CourseSession CourseSession { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}