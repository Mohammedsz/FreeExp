namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CenterID", "dbo.Centers");
            DropIndex("dbo.Courses", new[] { "CenterID" });
            RenameColumn(table: "dbo.Courses", name: "CenterID", newName: "Center_Id");
            AlterColumn("dbo.Courses", "Center_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Center_Id");
            AddForeignKey("dbo.Courses", "Center_Id", "dbo.Centers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Center_Id", "dbo.Centers");
            DropIndex("dbo.Courses", new[] { "Center_Id" });
            AlterColumn("dbo.Courses", "Center_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "Center_Id", newName: "CenterID");
            CreateIndex("dbo.Courses", "CenterID");
            AddForeignKey("dbo.Courses", "CenterID", "dbo.Centers", "Id", cascadeDelete: true);
        }
    }
}
