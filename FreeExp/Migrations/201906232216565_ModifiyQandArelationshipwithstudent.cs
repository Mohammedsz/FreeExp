namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiyQandArelationshipwithstudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QandAs", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.QandAs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QandAs", "Student_Id", "dbo.Students");
            DropIndex("dbo.QandAs", new[] { "CourseId" });
            DropIndex("dbo.QandAs", new[] { "User_Id" });
            DropIndex("dbo.QandAs", new[] { "Student_Id" });
            DropTable("dbo.QandAs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QandAs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionContent = c.String(),
                        AskedAt = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.QandAs", "Student_Id");
            CreateIndex("dbo.QandAs", "User_Id");
            CreateIndex("dbo.QandAs", "CourseId");
            AddForeignKey("dbo.QandAs", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.QandAs", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.QandAs", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
