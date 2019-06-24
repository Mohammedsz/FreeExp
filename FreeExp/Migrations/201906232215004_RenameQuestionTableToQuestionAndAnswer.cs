namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameQuestionTableToQuestionAndAnswer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Questions", newName: "QandAs");
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        URL = c.String(),
                        File = c.Binary(),
                        FileType = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            AddColumn("dbo.Courses", "Center_Id", c => c.Int());
            AlterColumn("dbo.CourseSessions", "Duration", c => c.Time(nullable: false, precision: 7));
            CreateIndex("dbo.Courses", "Center_Id");
            AddForeignKey("dbo.Courses", "Center_Id", "dbo.Centers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Center_Id", "dbo.Centers");
            DropIndex("dbo.CourseMaterials", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Center_Id" });
            AlterColumn("dbo.CourseSessions", "Duration", c => c.String());
            DropColumn("dbo.Courses", "Center_Id");
            DropTable("dbo.CourseMaterials");
            DropTable("dbo.Centers");
            RenameTable(name: "dbo.QandAs", newName: "Questions");
        }
    }
}
