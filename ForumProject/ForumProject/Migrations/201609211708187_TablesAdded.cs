namespace ForumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReplyContent = c.String(),
                        ThreadOfReply_Id = c.Int(),
                        UserThatReplied_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ThreadOfReply_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserThatReplied_Id)
                .Index(t => t.ThreadOfReply_Id)
                .Index(t => t.UserThatReplied_Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadName = c.String(),
                        ThreadContent = c.String(),
                        UserThatPosted_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserThatPosted_Id)
                .Index(t => t.UserThatPosted_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Team_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Team_Id");
            AddForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams", "Id");
            DropTable("dbo.RegisterViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 16),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 16),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Replies", "UserThatReplied_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Threads", "UserThatPosted_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "ThreadOfReply_Id", "dbo.Threads");
            DropIndex("dbo.AspNetUsers", new[] { "Team_Id" });
            DropIndex("dbo.Threads", new[] { "UserThatPosted_Id" });
            DropIndex("dbo.Replies", new[] { "UserThatReplied_Id" });
            DropIndex("dbo.Replies", new[] { "ThreadOfReply_Id" });
            DropColumn("dbo.AspNetUsers", "Team_Id");
            DropTable("dbo.Teams");
            DropTable("dbo.Threads");
            DropTable("dbo.Replies");
        }
    }
}
