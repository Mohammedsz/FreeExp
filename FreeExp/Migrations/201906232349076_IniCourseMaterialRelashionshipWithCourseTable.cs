namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniCourseMaterialRelashionshipWithCourseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CourseMaterials", new[] { "Course_Id" });
            RenameColumn(table: "dbo.CourseMaterials", name: "Course_Id", newName: "CourseID");
            AlterColumn("dbo.CourseMaterials", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseMaterials", "CourseID");
            AddForeignKey("dbo.CourseMaterials", "CourseID", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterials", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseMaterials", new[] { "CourseID" });
            AlterColumn("dbo.CourseMaterials", "CourseID", c => c.Int());
            RenameColumn(table: "dbo.CourseMaterials", name: "CourseID", newName: "Course_Id");
            CreateIndex("dbo.CourseMaterials", "Course_Id");
            AddForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
