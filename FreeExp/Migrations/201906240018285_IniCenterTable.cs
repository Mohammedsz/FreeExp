namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniCenterTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Centers", "Lat", c => c.Decimal(nullable: false, precision: 10, scale: 6));
            AddColumn("dbo.Centers", "lng", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Centers", "lng");
            DropColumn("dbo.Centers", "Lat");
        }
    }
}
