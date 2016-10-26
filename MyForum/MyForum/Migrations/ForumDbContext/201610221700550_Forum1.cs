namespace MyForum.Migrations.ForumDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SectionId = c.String(maxLength: 128),
                        PostId = c.String(maxLength: 128),
                        UserName = c.String(),
                        Body = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .Index(t => t.SectionId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SectionId = c.String(maxLength: 128),
                        Topic = c.String(),
                        Content = c.String(),
                        Username = c.String(),
                        Published = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Posts", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "SectionId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "SectionId" });
            DropTable("dbo.Sections");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
