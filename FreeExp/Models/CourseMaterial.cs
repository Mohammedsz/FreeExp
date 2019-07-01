using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace FreeExp.Models
{
    public class CourseMaterial
    {
        public int Id { get; set; }
        //Add material type
        public string Note { get; set; }
        public string URL { get; set; }
        public byte[] File { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }

    public class CourseMaterialConfigurations : EntityTypeConfiguration<CourseMaterial>
    {
        public CourseMaterialConfigurations()
        {
            HasRequired(t => t.Course).WithMany(t => t.Materials).HasForeignKey(t => t.CourseID).WillCascadeOnDelete(true);
        }
    }
}