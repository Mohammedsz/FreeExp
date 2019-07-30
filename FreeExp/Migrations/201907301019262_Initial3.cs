namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Center_Id", "dbo.Centers");
            DropIndex("dbo.Courses", new[] { "Center_Id" });
            DropColumn("dbo.Courses", "Center_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Center_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Center_Id");
            AddForeignKey("dbo.Courses", "Center_Id", "dbo.Centers", "Id");
        }
    }
}
