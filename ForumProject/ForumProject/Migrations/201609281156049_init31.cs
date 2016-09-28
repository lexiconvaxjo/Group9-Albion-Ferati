namespace ForumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init31 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ReplyViewModels");
        }
        
        public override void Down()
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
    }
}
