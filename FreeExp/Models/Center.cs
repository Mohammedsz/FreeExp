using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class Center
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}