using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class CourseMaterial
    {
        public int Id { get; set; }
        public string FileUri { get; set; }
        public string FileDsecription { get; set; }
        public Course Course { get; set; }
    }
}