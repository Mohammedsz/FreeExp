using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Lectures { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
        public virtual ICollection<Question> QandAs { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}