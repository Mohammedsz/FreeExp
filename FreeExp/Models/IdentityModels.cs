using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace FreeExp.Models
{
    public enum Gender : byte
    {
        Male,
        Female
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            QandAs = new HashSet<QandA>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string FName { get; set; }

        public string LName { get; set; }
        public string PhotoUrl { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        public string College { get; set; }

        public virtual ICollection<QandA> QandAs { get; set; }
        public virtual ICollection<PracticeQandAs> PracticeQandAs { get; set; }
        
    }

    public class PracticeQandAs
    {
        public PracticeQandAs()
        {
            AnswerDate = DateTime.Now;
        }
        public string UserId { get; set; }
        public DateTime AnswerDate { get; private set; }
        public string AnswerBody { get; set; }

        public int QandAId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual QandA QandA { get; set; }
    }

    public class PracticeQandAsConfigurations : EntityTypeConfiguration<PracticeQandAs>
    {
        public PracticeQandAsConfigurations()
        {
            HasKey(t => new { t.UserId, t.QandAId, t.AnswerDate });
            HasRequired(t => t.ApplicationUser).WithMany(t => t.PracticeQandAs).HasForeignKey(t => t.UserId);
            HasRequired(t => t.QandA).WithMany(t => t.PracticeQandAs).HasForeignKey(t => t.QandAId);
        }
    }

    [Table("Students")]
    public class Student : ApplicationUser
    {
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class ApplicationUserConfigurations : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfigurations()
        {
            HasMany(t => t.QandAs).WithRequired(t => t.User).HasForeignKey(t => t.UserOwnerId).WillCascadeOnDelete(false);
        }
    }

    [Table("Instructors")]
    public class Instructor : ApplicationUser
    {
        public Instructor()
        {
        }

        public string CV { get; set; }

        public Gender Gender { get; set; }

        public string City { get; set; }

        public string Town { get; set; }

        public string Degree { get; set; }

        [Display(Name = "Work Experince")]
        public int WorkExp { get; set; }

        public string FeildStudy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? GraduationYear { get; set; }

        public int GPA { get; set; }

        public string Certificate { get; set; }

        public string CertificateParty { get; set; }

        public string JobTitle { get; set; }

        public string JobOrganization { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? JobStartDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public class ApplicationRole : IdentityRole
        {
            public ApplicationRole() : base() { }
            public ApplicationRole(string name) : base(name) { }
            public string Description { get; set; }

        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

        public DbSet<PracticeQandAs> PracticeQandAs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseMaterial> CourseMaterials { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<CourseSession> CourseSessions { get; set; }
        public DbSet<QandA> QandAs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentGoingToSession> studentGoingToSessions { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfigurations());
            modelBuilder.Configurations.Add(new PracticeQandAsConfigurations());
            modelBuilder.Configurations.Add(new CourseMaterialConfigurations());
            modelBuilder.Configurations.Add(new CenterConfigrations());
            //modelBuilder.Configurations.Add(new StudentCoursesConfiguration());
            modelBuilder.Configurations.Add(new CourseSessionconfigration());
            //    modelBuilder.Entity<ApplicationUser>()
            //        .Property(u => u.BirthDate)
            //        .HasColumnType("datetime2");

            //        //(property => property.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }
    }
}