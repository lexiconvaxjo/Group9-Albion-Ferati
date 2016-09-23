namespace ForumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Threads", "Section_Id", c => c.Int());
            CreateIndex("dbo.Threads", "Section_Id");
            AddForeignKey("dbo.Threads", "Section_Id", "dbo.Sections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "Section_Id", "dbo.Sections");
            DropIndex("dbo.Threads", new[] { "Section_Id" });
            DropColumn("dbo.Threads", "Section_Id");
            DropTable("dbo.Sections");
        }
    }
}
