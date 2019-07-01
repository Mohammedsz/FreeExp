using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeExp.Models
{
    public class Center
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<CourseSession> CourseSessions { get; set; }
    }

    public class CenterConfigrations : EntityTypeConfiguration<Center>
    {
        public CenterConfigrations()
        {
            Property(e => e.Lat).HasPrecision(10, 6);
            Property(e => e.Lat).HasPrecision(10, 6);
        }
    }
}