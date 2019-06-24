namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityIn2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "WorkExp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "WorkExp");
        }
    }
}
