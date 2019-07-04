using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class Course
    {
        public Course()
        {
            //this.Students = new HashSet<StudentCourses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Lectures { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
        public virtual ICollection<QandA> QandAs { get; set; }
        public virtual ICollection<Student> Students { get; set; } //=>what ?
        public virtual ICollection<CourseMaterial> Materials { get; set; }
        public virtual Center Center { get; set; } //may be need more prop in bridge
        public int CenterID { get; set; }
        public string InstrucotrId { get; set; }
        public int DepartmentId { get; set; }
    }

    public class StudentCourses
    {
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }

    public class CourseConfigrations : EntityTypeConfiguration<Course>
    {
        public CourseConfigrations()
        {
            HasOptional(t => t.Center).WithMany(t => t.Courses).HasForeignKey(t => t.CenterID);
        }
    }

    public class StudentCoursesConfiguration : EntityTypeConfiguration<StudentCourses>
    {
        public StudentCoursesConfiguration()
        {
            HasKey(t => new { t.CourseId, t.StudentId });
            //HasRequired(t => t.Course).WithMany(t => t.Students).HasForeignKey(t => t.CourseId);
        }
    }
}