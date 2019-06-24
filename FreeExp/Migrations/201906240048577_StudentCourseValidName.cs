namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentCourseValidName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentCoursesssses", newName: "StudentCourses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StudentCourses", newName: "StudentCoursesssses");
        }
    }
}
