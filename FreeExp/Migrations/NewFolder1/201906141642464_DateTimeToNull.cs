namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "GraduationYear", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "JobStartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "JobStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "GraduationYear", c => c.DateTime(nullable: false));
        }
    }
}
