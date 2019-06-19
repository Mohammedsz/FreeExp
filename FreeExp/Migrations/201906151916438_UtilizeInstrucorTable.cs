namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UtilizeInstrucorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PhotoUrl = c.String(),
                        Gender = c.Byte(nullable: false),
                        City = c.String(),
                        Town = c.String(),
                        Degree = c.String(),
                        WorkExp = c.Int(nullable: false),
                        FeildStudy = c.String(),
                        GraduationYear = c.DateTime(),
                        GPA = c.Int(nullable: false),
                        Certificate = c.String(),
                        CertificateParty = c.String(),
                        JobTitle = c.String(),
                        JobOrganization = c.String(),
                        JobStartDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Courses", "Instructor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "Instructor_Id");
            AddForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors", "Id");
            DropColumn("dbo.AspNetUsers", "PhotoUrl");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Town");
            DropColumn("dbo.AspNetUsers", "Degree");
            DropColumn("dbo.AspNetUsers", "WorkExp");
            DropColumn("dbo.AspNetUsers", "FeildStudy");
            DropColumn("dbo.AspNetUsers", "GraduationYear");
            DropColumn("dbo.AspNetUsers", "GPA");
            DropColumn("dbo.AspNetUsers", "Certificate");
            DropColumn("dbo.AspNetUsers", "CertificateParty");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "JobOrganization");
            DropColumn("dbo.AspNetUsers", "JobStartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "JobStartDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "JobOrganization", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "CertificateParty", c => c.String());
            AddColumn("dbo.AspNetUsers", "Certificate", c => c.String());
            AddColumn("dbo.AspNetUsers", "GPA", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "GraduationYear", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "FeildStudy", c => c.String());
            AddColumn("dbo.AspNetUsers", "WorkExp", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Degree", c => c.String());
            AddColumn("dbo.AspNetUsers", "Town", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhotoUrl", c => c.String());
            DropForeignKey("dbo.Instructors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.Instructors", new[] { "Id" });
            DropIndex("dbo.Courses", new[] { "Instructor_Id" });
            DropColumn("dbo.Courses", "Instructor_Id");
            DropTable("dbo.Instructors");
        }
    }
}
