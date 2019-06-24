namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiyQandArelationshipwithstudent3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QandAs", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.QandAs", "ApplicationUser_Id");
            AddForeignKey("dbo.QandAs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QandAs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.QandAs", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.QandAs", "ApplicationUser_Id");
        }
    }
}
