namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseSessionRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSessions", "CnterId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseSessions", "CnterId");
            AddForeignKey("dbo.CourseSessions", "CnterId", "dbo.Centers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseSessions", "CnterId", "dbo.Centers");
            DropIndex("dbo.CourseSessions", new[] { "CnterId" });
            DropColumn("dbo.CourseSessions", "CnterId");
        }
    }
}
