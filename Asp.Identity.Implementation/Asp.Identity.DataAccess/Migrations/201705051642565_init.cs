namespace Asp.Identity.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Type = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        UserForm_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.UserForms", t => t.UserForm_Id)
                .Index(t => t.QuestionId)
                .Index(t => t.UserForm_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        HaveAnswer = c.Boolean(nullable: false),
                        WorkForm_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.WorkForm_Id)
                .Index(t => t.WorkForm_Id);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.FormId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FormId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserForms", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserForms", "FormId", "dbo.Forms");
            DropForeignKey("dbo.Answers", "UserForm_Id", "dbo.UserForms");
            DropForeignKey("dbo.LoginHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "WorkForm_Id", "dbo.Forms");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.UserForms", new[] { "UserId" });
            DropIndex("dbo.UserForms", new[] { "FormId" });
            DropIndex("dbo.LoginHistories", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "WorkForm_Id" });
            DropIndex("dbo.Answers", new[] { "UserForm_Id" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.UserForms");
            DropTable("dbo.Users");
            DropTable("dbo.LoginHistories");
            DropTable("dbo.Forms");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
