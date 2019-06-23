namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QandAs", newName: "Questions");
            DropForeignKey("dbo.CourseApplicationUsers", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CourseApplicationUsers", new[] { "Course_Id" });
            DropIndex("dbo.CourseApplicationUsers", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Questions", "QuestionContent", c => c.String());
            AddColumn("dbo.Questions", "Student_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Questions", "Student_Id");
            AddForeignKey("dbo.Questions", "Student_Id", "dbo.Students", "Id");
            DropColumn("dbo.AspNetUsers", "AppliedAsInstructor");
            DropColumn("dbo.Questions", "Question");
            DropTable("dbo.CourseApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseApplicationUsers",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.ApplicationUser_Id });
            
            AddColumn("dbo.Questions", "Question", c => c.String());
            AddColumn("dbo.AspNetUsers", "AppliedAsInstructor", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Students", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Questions", "Student_Id", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropIndex("dbo.Questions", new[] { "Student_Id" });
            DropColumn("dbo.Questions", "Student_Id");
            DropColumn("dbo.Questions", "QuestionContent");
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            CreateIndex("dbo.CourseApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.CourseApplicationUsers", "Course_Id");
            AddForeignKey("dbo.CourseApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseApplicationUsers", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Questions", newName: "QandAs");
        }
    }
}
