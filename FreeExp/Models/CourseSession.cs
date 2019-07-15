using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace FreeExp.Models
{
    public class CourseSession
    {
        public int Id { get; set; }
        public string Name { get; set; }//why ?
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public DateTime SessionDate { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime EndAt { get; set; }
        public string Address { get; set; }
        public string VideoUrl { get; set; }
        public string YouTubeIFrame { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }

    public class CourseSessionconfigration : EntityTypeConfiguration<CourseSession>
    {
        public CourseSessionconfigration()
        {
            //HasRequired(t => t.Center).WithMany(t => t.CourseSessions).HasForeignKey(t => t.CnterId);
        }
    }
}