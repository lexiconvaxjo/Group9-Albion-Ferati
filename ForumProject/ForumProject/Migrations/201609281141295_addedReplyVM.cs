namespace ForumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedReplyVM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReplyViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReplyContent = c.String(),
                        ThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReplyViewModels");
        }
    }
}
