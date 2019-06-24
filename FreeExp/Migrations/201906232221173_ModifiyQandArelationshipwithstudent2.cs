namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiyQandArelationshipwithstudent2 : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QandAs", "CourseId", "dbo.Courses");
            DropIndex("dbo.QandAs", new[] { "CourseId" });
            DropTable("dbo.QandAs");
        }
    }
}
