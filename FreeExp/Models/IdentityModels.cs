using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreeExp.Models
{
    public enum Gender : byte
    {
        Male,
        Female
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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

        public ApplicationUser()
        {
            this.Courses = new HashSet<Course>();
        }

        public string FName { get; set; }

        public string LName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        public string PhotoUrl { get; set; }

        public Gender Gender { get; set; }

        public string City { get; set; }

        public string Town { get; set; }

        public string Degree { get; set; }

        [Display(Name = "Work Experince")]
        public int WorkExp { get; set; }

        public string College { get; set; }

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

        public bool AppliedAsInstructor { get; set; }
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ApplicationUser>()
        //        .Property(u => u.BirthDate)
        //        .HasColumnType("datetime2");

        //        //(property => property.HasColumnType("datetime2"));
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}