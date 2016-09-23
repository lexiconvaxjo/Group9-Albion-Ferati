namespace ForumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedSomething : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreateThreadViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Section_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Section_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreateThreadViewModels", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CreateThreadViewModels", "Section_Id", "dbo.Sections");
            DropIndex("dbo.CreateThreadViewModels", new[] { "User_Id" });
            DropIndex("dbo.CreateThreadViewModels", new[] { "Section_Id" });
            DropTable("dbo.CreateThreadViewModels");
        }
    }
}
