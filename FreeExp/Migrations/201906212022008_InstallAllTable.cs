namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallAllTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Questions", "CourseId", "dbo.Courses");
            DropIndex("dbo.Questions", new[] { "CourseId" });
            DropIndex("dbo.Questions", new[] { "User_Id" });
            DropIndex("dbo.Questions", new[] { "Student_Id" });
            RenameColumn(table: "dbo.Questions", name: "CourseId", newName: "Course_Id");
            CreateTable(
                "dbo.CourseMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileUri = c.String(),
                        FileDsecription = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.CourseCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Latitude = c.Int(nullable: false),
                        longtude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CourseSessions", "CourseCenter_Id", c => c.Int());
            AlterColumn("dbo.Questions", "Course_Id", c => c.Int());
            CreateIndex("dbo.CourseSessions", "CourseCenter_Id");
            CreateIndex("dbo.Questions", "Course_Id");
            AddForeignKey("dbo.CourseSessions", "CourseCenter_Id", "dbo.CourseCenters", "Id");
            AddForeignKey("dbo.Questions", "Course_Id", "dbo.Courses", "Id");
            DropColumn("dbo.Questions", "QuestionContent");
            DropColumn("dbo.Questions", "AskedAt");
            DropColumn("dbo.Questions", "UserId");
            DropColumn("dbo.Questions", "User_Id");
            DropColumn("dbo.Questions", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Student_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Questions", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Questions", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "AskedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "QuestionContent", c => c.String());
            DropForeignKey("dbo.Questions", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseSessions", "CourseCenter_Id", "dbo.CourseCenters");
            DropForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Questions", new[] { "Course_Id" });
            DropIndex("dbo.CourseSessions", new[] { "CourseCenter_Id" });
            DropIndex("dbo.CourseMaterials", new[] { "Course_Id" });
            AlterColumn("dbo.Questions", "Course_Id", c => c.Int(nullable: false));
            DropColumn("dbo.CourseSessions", "CourseCenter_Id");
            DropTable("dbo.CourseCenters");
            DropTable("dbo.CourseMaterials");
            RenameColumn(table: "dbo.Questions", name: "Course_Id", newName: "CourseId");
            CreateIndex("dbo.Questions", "Student_Id");
            CreateIndex("dbo.Questions", "User_Id");
            CreateIndex("dbo.Questions", "CourseId");
            AddForeignKey("dbo.Questions", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Questions", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
