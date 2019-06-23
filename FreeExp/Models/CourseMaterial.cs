using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeExp.Models
{
    public class CourseMaterial
    {
        public int Id { get; set; }
        //Add material type
        public string Note { get; set; }
        public string URL { get; set; }
        public byte[] File { get; set; }
        public string FileType { get; set; }
        public virtual Course Course { get; set; }
    }
}