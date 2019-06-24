namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FName", c => c.String(maxLength: 30));
            AddColumn("dbo.AspNetUsers", "LName", c => c.String(maxLength: 30));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "Town", c => c.String());
            AddColumn("dbo.AspNetUsers", "College", c => c.String());
            AddColumn("dbo.AspNetUsers", "FeildStudy", c => c.String());
            AddColumn("dbo.AspNetUsers", "GraduationYear", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "GPA", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Certificate", c => c.String());
            AddColumn("dbo.AspNetUsers", "certificateParty", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobOrganization", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "Bio");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Bio", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropColumn("dbo.AspNetUsers", "JobStartDate");
            DropColumn("dbo.AspNetUsers", "JobOrganization");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "certificateParty");
            DropColumn("dbo.AspNetUsers", "Certificate");
            DropColumn("dbo.AspNetUsers", "GPA");
            DropColumn("dbo.AspNetUsers", "GraduationYear");
            DropColumn("dbo.AspNetUsers", "FeildStudy");
            DropColumn("dbo.AspNetUsers", "College");
            DropColumn("dbo.AspNetUsers", "Town");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "LName");
            DropColumn("dbo.AspNetUsers", "FName");
        }
    }
}
