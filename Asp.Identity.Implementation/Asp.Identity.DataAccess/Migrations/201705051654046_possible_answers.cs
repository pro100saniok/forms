namespace Asp.Identity.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class possible_answers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Answers", newName: "UserAnswers");
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            AddColumn("dbo.UserAnswers", "PossibleAnswerId", c => c.Int());
            CreateIndex("dbo.UserAnswers", "PossibleAnswerId");
            AddForeignKey("dbo.UserAnswers", "PossibleAnswerId", "dbo.PossibleAnswers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PossibleAnswers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.UserAnswers", "PossibleAnswerId", "dbo.PossibleAnswers");
            DropIndex("dbo.PossibleAnswers", new[] { "Question_Id" });
            DropIndex("dbo.UserAnswers", new[] { "PossibleAnswerId" });
            DropColumn("dbo.UserAnswers", "PossibleAnswerId");
            DropTable("dbo.PossibleAnswers");
            RenameTable(name: "dbo.UserAnswers", newName: "Answers");
        }
    }
}
