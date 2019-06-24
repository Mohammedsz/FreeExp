namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniPracticeQandATable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PracticeQandAs",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        QandAId = c.Int(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.QandAId, t.AnswerDate })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.QandAs", t => t.QandAId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.QandAId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PracticeQandAs", "QandAId", "dbo.QandAs");
            DropForeignKey("dbo.PracticeQandAs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PracticeQandAs", new[] { "QandAId" });
            DropIndex("dbo.PracticeQandAs", new[] { "UserId" });
            DropTable("dbo.PracticeQandAs");
        }
    }
}
