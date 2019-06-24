namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserTableDataAttr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "FName", c => c.String(maxLength: 30));
        }
    }
}
