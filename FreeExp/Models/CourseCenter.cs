﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class CourseCenter
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
    }
}