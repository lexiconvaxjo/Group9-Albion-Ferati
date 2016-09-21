namespace ForumProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            RenameColumn(table: "dbo.Users", name: "Id", newName: "UserID");
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            RenameColumn(table: "dbo.Users", name: "UserID", newName: "Id");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}
