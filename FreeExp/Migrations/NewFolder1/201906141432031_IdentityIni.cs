namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityIni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "AppliedAsInstructor", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "WorkExp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "WorkExp", c => c.String());
            DropColumn("dbo.AspNetUsers", "AppliedAsInstructor");
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
