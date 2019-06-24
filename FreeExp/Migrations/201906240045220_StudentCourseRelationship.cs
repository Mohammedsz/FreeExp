namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentCourseRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Center_Id", "dbo.Centers");
            DropIndex("dbo.Courses", new[] { "Center_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            RenameColumn(table: "dbo.Courses", name: "Center_Id", newName: "CenterID");
            CreateTable(
                "dbo.StudentCoursesssses",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.StudentId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            AddColumn("dbo.Courses", "InstrucotrId", c => c.String());
            AlterColumn("dbo.Courses", "CenterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "CenterID");
            AddForeignKey("dbo.Courses", "CenterID", "dbo.Centers", "Id", cascadeDelete: true);
            DropTable("dbo.StudentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id });
            
            DropForeignKey("dbo.Courses", "CenterID", "dbo.Centers");
            DropForeignKey("dbo.StudentCoursesssses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCoursesssses", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentCoursesssses", new[] { "StudentId" });
            DropIndex("dbo.StudentCoursesssses", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "CenterID" });
            AlterColumn("dbo.Courses", "CenterID", c => c.Int());
            DropColumn("dbo.Courses", "InstrucotrId");
            DropTable("dbo.StudentCoursesssses");
            RenameColumn(table: "dbo.Courses", name: "CenterID", newName: "Center_Id");
            CreateIndex("dbo.StudentCourses", "Course_Id");
            CreateIndex("dbo.StudentCourses", "Student_Id");
            CreateIndex("dbo.Courses", "Center_Id");
            AddForeignKey("dbo.Courses", "Center_Id", "dbo.Centers", "Id");
            AddForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
