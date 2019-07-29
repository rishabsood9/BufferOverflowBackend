namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerEntities",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        answers = c.String(),
                        QuestionId = c.Int(nullable: false),
                        useremail = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        NumberOfUpVotes = c.Int(nullable: false),
                        NumberOfDownVotes = c.Int(nullable: false),
                        Ques = c.String(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.QuestionEntities", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.useremail)
                .Index(t => t.QuestionId)
                .Index(t => t.useremail);
            
            CreateTable(
                "dbo.QuestionEntities",
                c => new
                    {
                        questionId = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        tags = c.String(),
                        NumberOfAnswers = c.Int(nullable: false),
                        QuestionImage = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.questionId)
                .ForeignKey("dbo.UserEntities", t => t.username)
                .Index(t => t.username);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        ProfileImage = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
            CreateTable(
                "dbo.VoteEntities",
                c => new
                    {
                        voteId = c.Int(nullable: false, identity: true),
                        vote = c.Boolean(nullable: false),
                        userId = c.String(maxLength: 128),
                        answerId = c.Int(nullable: false),
                        voter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.voteId)
                .ForeignKey("dbo.AnswerEntities", t => t.answerId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.answerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoteEntities", "userId", "dbo.UserEntities");
            DropForeignKey("dbo.VoteEntities", "answerId", "dbo.AnswerEntities");
            DropForeignKey("dbo.QuestionEntities", "username", "dbo.UserEntities");
            DropForeignKey("dbo.AnswerEntities", "useremail", "dbo.UserEntities");
            DropForeignKey("dbo.AnswerEntities", "QuestionId", "dbo.QuestionEntities");
            DropIndex("dbo.VoteEntities", new[] { "answerId" });
            DropIndex("dbo.VoteEntities", new[] { "userId" });
            DropIndex("dbo.QuestionEntities", new[] { "username" });
            DropIndex("dbo.AnswerEntities", new[] { "useremail" });
            DropIndex("dbo.AnswerEntities", new[] { "QuestionId" });
            DropTable("dbo.VoteEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.QuestionEntities");
            DropTable("dbo.AnswerEntities");
        }
    }
}
