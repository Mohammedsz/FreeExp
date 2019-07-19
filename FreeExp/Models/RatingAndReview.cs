using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class RatingAndReview
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int Rating { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}