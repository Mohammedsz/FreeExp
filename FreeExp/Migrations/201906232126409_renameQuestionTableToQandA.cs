namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameQuestionTableToQandA : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Questions", newName: "QandAs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.QandAs", newName: "Questions");
        }
    }
}
