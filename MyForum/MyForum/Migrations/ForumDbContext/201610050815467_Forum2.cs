namespace MyForum.Migrations.ForumDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "DateTime");
            DropColumn("dbo.Posts", "PostedOn");
            DropColumn("dbo.Posts", "Modified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Modified", c => c.DateTime());
            AddColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
