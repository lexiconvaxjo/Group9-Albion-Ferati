namespace MyForum.Migrations.ForumDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Comment", newName: "Comments");
            RenameTable(name: "dbo.Post", newName: "Posts");
            RenameTable(name: "dbo.Section", newName: "Sections");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Sections", newName: "Section");
            RenameTable(name: "dbo.Posts", newName: "Post");
            RenameTable(name: "dbo.Comments", newName: "Comment");
        }
    }
}
