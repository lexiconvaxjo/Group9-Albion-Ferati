namespace MyForum.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "JoinDate");
            DropColumn("dbo.AspNetUsers", "LastLoginDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
        }
    }
}
