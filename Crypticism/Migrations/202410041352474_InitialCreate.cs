namespace Crypticism.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAnonymous = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        RepliedOnReviewId = c.Int(nullable: false),
                        RepliedOnCommentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.RepliedOnCommentId)
                .ForeignKey("dbo.Reviews", t => t.RepliedOnReviewId, cascadeDelete: true)
                .Index(t => t.RepliedOnReviewId)
                .Index(t => t.RepliedOnCommentId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false),
                        IsUserVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        IsCompany = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        IsVerified = c.Boolean(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Comments", "RepliedOnReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Reviews", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "RepliedOnCommentId", "dbo.Comments");
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Companies", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "CompanyId" });
            DropIndex("dbo.Comments", new[] { "RepliedOnCommentId" });
            DropIndex("dbo.Comments", new[] { "RepliedOnReviewId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
            DropTable("dbo.Reviews");
            DropTable("dbo.Comments");
        }
    }
}
