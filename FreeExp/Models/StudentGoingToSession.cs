using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class StudentGoingToSession
    {
        public int Id { get; set; }
        public int CourseSessionId { get; set; }
        public string UserId { get; set; }
        public Student student { get; set; }
        public CourseSession CourseSession { get; set; }
    }
}