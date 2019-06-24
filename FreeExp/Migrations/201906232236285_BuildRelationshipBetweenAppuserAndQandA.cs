namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildRelationshipBetweenAppuserAndQandA : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.QandAs", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.QandAs", name: "ApplicationUser_Id", newName: "UserOwnerId");
            AlterColumn("dbo.QandAs", "UserOwnerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.QandAs", "UserOwnerId");
            DropColumn("dbo.QandAs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QandAs", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.QandAs", new[] { "UserOwnerId" });
            AlterColumn("dbo.QandAs", "UserOwnerId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.QandAs", name: "UserOwnerId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.QandAs", "ApplicationUser_Id");
        }
    }
}
