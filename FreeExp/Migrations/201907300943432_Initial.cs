namespace FreeExp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        Name = c.String(),
                        Duration = c.String(),
                        Lectures = c.Int(nullable: false),
                        LastUpdateOn = c.DateTime(nullable: false),
                        Description = c.String(),
                        Requirments = c.String(),
                        Level = c.String(),
                        CenterID = c.Int(nullable: false),
                        InstrucotrId = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Instructor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id)
                .Index(t => t.CenterID)
                .Index(t => t.DepartmentId)
                .Index(t => t.Instructor_Id);
            
            CreateTable(
                "dbo.CourseSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                        Description = c.String(),
                        SessionDate = c.DateTime(nullable: false),
                        StartFrom = c.DateTime(nullable: false),
                        EndAt = c.DateTime(nullable: false),
                        Address = c.String(),
                        VideoUrl = c.String(),
                        YouTubeIFrame = c.String(),
                        CourseId = c.Int(nullable: false),
                        Center_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Centers", t => t.Center_Id)
                .Index(t => t.CourseId)
                .Index(t => t.Center_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        PhotoUrl = c.String(),
                        BirthDate = c.DateTime(),
                        College = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PracticeQandAs",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        QandAId = c.Int(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                        AnswerBody = c.String(),
                    })
                .PrimaryKey(t => new { t.UserId, t.QandAId, t.AnswerDate })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.QandAs", t => t.QandAId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.QandAId);
            
            CreateTable(
                "dbo.QandAs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionContent = c.String(),
                        AskedAt = c.DateTime(nullable: false),
                        UserOwnerId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserOwnerId)
                .Index(t => t.UserOwnerId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CourseMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        URL = c.String(),
                        File = c.Binary(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        RollId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RollId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentGoingToSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseSessionId = c.Int(nullable: false),
                        UserId = c.String(),
                        student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseSessions", t => t.CourseSessionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.student_Id)
                .Index(t => t.CourseSessionId)
                .Index(t => t.student_Id);
            
            CreateTable(
                "dbo.StudentCourses1",
                c => new
                    {
                        Student_Id = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CV = c.String(),
                        Gender = c.Byte(nullable: false),
                        City = c.String(),
                        Town = c.String(),
                        Degree = c.String(),
                        WorkExp = c.Int(nullable: false),
                        FeildStudy = c.String(),
                        GraduationYear = c.DateTime(),
                        GPA = c.Int(nullable: false),
                        Certificate = c.String(),
                        CertificateParty = c.String(),
                        JobTitle = c.String(),
                        JobOrganization = c.String(),
                        JobStartDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Instructors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentGoingToSessions", "student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentGoingToSessions", "CourseSessionId", "dbo.CourseSessions");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RatingAndReviews", "StudentId", "dbo.Students");
            DropForeignKey("dbo.RatingAndReviews", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseSessions", "Center_Id", "dbo.Centers");
            DropForeignKey("dbo.CourseMaterials", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.PracticeQandAs", "QandAId", "dbo.QandAs");
            DropForeignKey("dbo.PracticeQandAs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentCourses1", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses1", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QandAs", "UserOwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.QandAs", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseSessions", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CenterID", "dbo.Centers");
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Instructors", new[] { "Id" });
            DropIndex("dbo.StudentCourses1", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses1", new[] { "Student_Id" });
            DropIndex("dbo.StudentGoingToSessions", new[] { "student_Id" });
            DropIndex("dbo.StudentGoingToSessions", new[] { "CourseSessionId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RatingAndReviews", new[] { "CourseId" });
            DropIndex("dbo.RatingAndReviews", new[] { "StudentId" });
            DropIndex("dbo.CourseMaterials", new[] { "CourseID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.QandAs", new[] { "CourseId" });
            DropIndex("dbo.QandAs", new[] { "UserOwnerId" });
            DropIndex("dbo.PracticeQandAs", new[] { "QandAId" });
            DropIndex("dbo.PracticeQandAs", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CourseSessions", new[] { "Center_Id" });
            DropIndex("dbo.CourseSessions", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "Instructor_Id" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "CenterID" });
            DropTable("dbo.Students");
            DropTable("dbo.Instructors");
            DropTable("dbo.StudentCourses1");
            DropTable("dbo.StudentGoingToSessions");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RatingAndReviews");
            DropTable("dbo.CourseMaterials");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.QandAs");
            DropTable("dbo.PracticeQandAs");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Departments");
            DropTable("dbo.CourseSessions");
            DropTable("dbo.Courses");
            DropTable("dbo.Centers");
        }
    }
}
