namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameQandA : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Questions", newName: "QandAs");
            DropIndex("dbo.QandAs", new[] { "Student_Id" });
            DropColumn("dbo.QandAs", "User_Id");
            RenameColumn(table: "dbo.QandAs", name: "Student_Id", newName: "User_Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.QandAs", name: "User_Id", newName: "Student_Id");
            AddColumn("dbo.QandAs", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.QandAs", "Student_Id");
            RenameTable(name: "dbo.QandAs", newName: "Questions");
        }
    }
}
