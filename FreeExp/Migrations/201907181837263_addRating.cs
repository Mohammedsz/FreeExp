namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingAndReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingAndReviews", "StudentId", "dbo.Students");
            DropForeignKey("dbo.RatingAndReviews", "CourseId", "dbo.Courses");
            DropIndex("dbo.RatingAndReviews", new[] { "CourseId" });
            DropIndex("dbo.RatingAndReviews", new[] { "StudentId" });
            DropTable("dbo.RatingAndReviews");
        }
    }
}
