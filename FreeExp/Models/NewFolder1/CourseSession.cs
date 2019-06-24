using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class CourseSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public DateTime SessionDate { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime EndAt { get; set; }
        public string Address { get; set; }
        public string VideoUrl { get; set; }
        public string YouTubeIFrame { get; set; }

    }
}