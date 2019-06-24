using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public DateTime AskedAt { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}