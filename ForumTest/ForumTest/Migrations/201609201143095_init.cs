namespace ForumTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessMask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        AccessFlag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Board", t => t.BoardId)
                .Index(t => t.BoardId);
            
            CreateTable(
                "dbo.Board",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        Disabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Board", t => t.BoardId)
                .Index(t => t.BoardId);
            
            CreateTable(
                "dbo.Forum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        SortOrder = c.Int(nullable: false),
                        ParentForumId = c.Int(),
                        Description = c.String(),
                        LastPosted = c.DateTime(),
                        LastTopicId = c.Int(),
                        LastPostId = c.Int(),
                        LastPostUserId = c.Int(),
                        LastPostUsername = c.String(maxLength: 256),
                        TopicCount = c.Int(nullable: false),
                        PostCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.LastPostId)
                .ForeignKey("dbo.ForumUser", t => t.LastPostUserId)
                .ForeignKey("dbo.Topic", t => t.LastTopicId)
                .ForeignKey("dbo.Forum", t => t.ParentForumId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.ParentForumId)
                .Index(t => t.LastTopicId)
                .Index(t => t.LastPostId)
                .Index(t => t.LastPostUserId);
            
            CreateTable(
                "dbo.FollowForum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForumId = c.Int(nullable: false),
                        ForumUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.ForumUserId)
                .ForeignKey("dbo.Forum", t => t.ForumId)
                .Index(t => t.ForumId)
                .Index(t => t.ForumUserId);
            
            CreateTable(
                "dbo.ForumUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderId = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 256),
                        EmailAddress = c.String(nullable: false, maxLength: 200),
                        FirstVisit = c.DateTime(nullable: false),
                        LastVisit = c.DateTime(nullable: false),
                        LastIP = c.String(maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Timezone = c.String(nullable: false, maxLength: 100),
                        Culture = c.String(nullable: false, maxLength: 10),
                        FullName = c.String(maxLength: 200),
                        UserFlag = c.Int(nullable: false),
                        UseFullName = c.Boolean(nullable: false),
                        ExternalAccount = c.Boolean(nullable: false),
                        ExternalProvider = c.String(maxLength: 50),
                        ExternalProviderId = c.String(maxLength: 200),
                        Theme = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForumAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForumId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        AccessMaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessMask", t => t.AccessMaskId)
                .ForeignKey("dbo.Forum", t => t.ForumId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .Index(t => t.ForumId)
                .Index(t => t.GroupId)
                .Index(t => t.AccessMaskId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Indent = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Body = c.String(nullable: false),
                        IP = c.String(nullable: false, maxLength: 50),
                        Edited = c.DateTime(),
                        Flag = c.Int(nullable: false),
                        EditReason = c.String(maxLength: 500),
                        ModeratorChanged = c.Boolean(nullable: false),
                        DeleteReason = c.String(maxLength: 500),
                        TopicId = c.Int(nullable: false),
                        ReplyToPostId = c.Int(),
                        AuthorId = c.Int(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 256),
                        Posted = c.DateTime(nullable: false),
                        SpamScore = c.Int(nullable: false),
                        SpamReporters = c.Int(nullable: false),
                        CustomProperties = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.AuthorId)
                .ForeignKey("dbo.Post", t => t.ReplyToPostId)
                .ForeignKey("dbo.Topic", t => t.TopicId)
                .Index(t => t.TopicId)
                .Index(t => t.ReplyToPostId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Attachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Filename = c.String(nullable: false, maxLength: 200),
                        PostId = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        DownloadCount = c.Int(nullable: false),
                        Path = c.String(nullable: false, maxLength: 500),
                        AuthorId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.AuthorId)
                .ForeignKey("dbo.Post", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        ViewCount = c.Int(nullable: false),
                        PostCount = c.Int(nullable: false),
                        Flag = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        LastPosted = c.DateTime(nullable: false),
                        LastPostId = c.Int(),
                        LastPostAuthorId = c.Int(),
                        LastPostUsername = c.String(maxLength: 256),
                        ForumId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 256),
                        Posted = c.DateTime(nullable: false),
                        SpamScore = c.Int(nullable: false),
                        SpamReporters = c.Int(nullable: false),
                        OriginalTopicId = c.Int(),
                        CustomProperties = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.AuthorId)
                .ForeignKey("dbo.Post", t => t.LastPostId)
                .ForeignKey("dbo.ForumUser", t => t.LastPostAuthorId)
                .ForeignKey("dbo.Topic", t => t.OriginalTopicId)
                .ForeignKey("dbo.Forum", t => t.ForumId)
                .Index(t => t.LastPostId)
                .Index(t => t.LastPostAuthorId)
                .Index(t => t.ForumId)
                .Index(t => t.AuthorId)
                .Index(t => t.OriginalTopicId);
            
            CreateTable(
                "dbo.FollowTopic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        ForumUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.ForumUserId)
                .ForeignKey("dbo.Topic", t => t.TopicId)
                .Index(t => t.TopicId)
                .Index(t => t.ForumUserId);
            
            CreateTable(
                "dbo.AddOnConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 50),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BannedIP",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP = c.String(nullable: false, maxLength: 50),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForumSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 100),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForumTrack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastViewed = c.DateTime(nullable: false),
                        ForumId = c.Int(nullable: false),
                        ForumUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forum", t => t.ForumId)
                .ForeignKey("dbo.ForumUser", t => t.ForumUserId)
                .Index(t => t.ForumId)
                .Index(t => t.ForumUserId);
            
            CreateTable(
                "dbo.GroupMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        ForumUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.ForumUserId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .Index(t => t.GroupId)
                .Index(t => t.ForumUserId);
            
            CreateTable(
                "dbo.PostReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Reason = c.String(nullable: false, maxLength: 500),
                        ReportedById = c.Int(nullable: false),
                        Feedback = c.Boolean(nullable: false),
                        Resolved = c.Boolean(nullable: false),
                        ResolvedById = c.Int(),
                        ResolvedTimestamp = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId)
                .ForeignKey("dbo.ForumUser", t => t.ReportedById)
                .ForeignKey("dbo.ForumUser", t => t.ResolvedById)
                .Index(t => t.PostId)
                .Index(t => t.ReportedById)
                .Index(t => t.ResolvedById);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TopicTrack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastViewed = c.DateTime(nullable: false),
                        TopicId = c.Int(nullable: false),
                        ForumUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumUser", t => t.ForumUserId)
                .ForeignKey("dbo.Topic", t => t.TopicId)
                .Index(t => t.TopicId)
                .Index(t => t.ForumUserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        LastActivityDate = c.DateTime(nullable: false),
                        LastLockoutDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.TopicTrack", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.TopicTrack", "ForumUserId", "dbo.ForumUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PostReport", "ResolvedById", "dbo.ForumUser");
            DropForeignKey("dbo.PostReport", "ReportedById", "dbo.ForumUser");
            DropForeignKey("dbo.PostReport", "PostId", "dbo.Post");
            DropForeignKey("dbo.GroupMember", "GroupId", "dbo.Group");
            DropForeignKey("dbo.GroupMember", "ForumUserId", "dbo.ForumUser");
            DropForeignKey("dbo.ForumTrack", "ForumUserId", "dbo.ForumUser");
            DropForeignKey("dbo.ForumTrack", "ForumId", "dbo.Forum");
            DropForeignKey("dbo.AccessMask", "BoardId", "dbo.Board");
            DropForeignKey("dbo.Category", "BoardId", "dbo.Board");
            DropForeignKey("dbo.Forum", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Topic", "ForumId", "dbo.Forum");
            DropForeignKey("dbo.Forum", "ParentForumId", "dbo.Forum");
            DropForeignKey("dbo.Forum", "LastTopicId", "dbo.Topic");
            DropForeignKey("dbo.Forum", "LastPostUserId", "dbo.ForumUser");
            DropForeignKey("dbo.Forum", "LastPostId", "dbo.Post");
            DropForeignKey("dbo.Post", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.Topic", "OriginalTopicId", "dbo.Topic");
            DropForeignKey("dbo.Topic", "LastPostAuthorId", "dbo.ForumUser");
            DropForeignKey("dbo.Topic", "LastPostId", "dbo.Post");
            DropForeignKey("dbo.FollowTopic", "TopicId", "dbo.Topic");
            DropForeignKey("dbo.FollowTopic", "ForumUserId", "dbo.ForumUser");
            DropForeignKey("dbo.Topic", "AuthorId", "dbo.ForumUser");
            DropForeignKey("dbo.Post", "ReplyToPostId", "dbo.Post");
            DropForeignKey("dbo.Post", "AuthorId", "dbo.ForumUser");
            DropForeignKey("dbo.Attachment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Attachment", "AuthorId", "dbo.ForumUser");
            DropForeignKey("dbo.ForumAccess", "GroupId", "dbo.Group");
            DropForeignKey("dbo.ForumAccess", "ForumId", "dbo.Forum");
            DropForeignKey("dbo.ForumAccess", "AccessMaskId", "dbo.AccessMask");
            DropForeignKey("dbo.FollowForum", "ForumId", "dbo.Forum");
            DropForeignKey("dbo.FollowForum", "ForumUserId", "dbo.ForumUser");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TopicTrack", new[] { "ForumUserId" });
            DropIndex("dbo.TopicTrack", new[] { "TopicId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.PostReport", new[] { "ResolvedById" });
            DropIndex("dbo.PostReport", new[] { "ReportedById" });
            DropIndex("dbo.PostReport", new[] { "PostId" });
            DropIndex("dbo.GroupMember", new[] { "ForumUserId" });
            DropIndex("dbo.GroupMember", new[] { "GroupId" });
            DropIndex("dbo.ForumTrack", new[] { "ForumUserId" });
            DropIndex("dbo.ForumTrack", new[] { "ForumId" });
            DropIndex("dbo.FollowTopic", new[] { "ForumUserId" });
            DropIndex("dbo.FollowTopic", new[] { "TopicId" });
            DropIndex("dbo.Topic", new[] { "OriginalTopicId" });
            DropIndex("dbo.Topic", new[] { "AuthorId" });
            DropIndex("dbo.Topic", new[] { "ForumId" });
            DropIndex("dbo.Topic", new[] { "LastPostAuthorId" });
            DropIndex("dbo.Topic", new[] { "LastPostId" });
            DropIndex("dbo.Attachment", new[] { "AuthorId" });
            DropIndex("dbo.Attachment", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "AuthorId" });
            DropIndex("dbo.Post", new[] { "ReplyToPostId" });
            DropIndex("dbo.Post", new[] { "TopicId" });
            DropIndex("dbo.ForumAccess", new[] { "AccessMaskId" });
            DropIndex("dbo.ForumAccess", new[] { "GroupId" });
            DropIndex("dbo.ForumAccess", new[] { "ForumId" });
            DropIndex("dbo.FollowForum", new[] { "ForumUserId" });
            DropIndex("dbo.FollowForum", new[] { "ForumId" });
            DropIndex("dbo.Forum", new[] { "LastPostUserId" });
            DropIndex("dbo.Forum", new[] { "LastPostId" });
            DropIndex("dbo.Forum", new[] { "LastTopicId" });
            DropIndex("dbo.Forum", new[] { "ParentForumId" });
            DropIndex("dbo.Forum", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "BoardId" });
            DropIndex("dbo.AccessMask", new[] { "BoardId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.TopicTrack");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PostReport");
            DropTable("dbo.GroupMember");
            DropTable("dbo.ForumTrack");
            DropTable("dbo.ForumSettings");
            DropTable("dbo.BannedIP");
            DropTable("dbo.AddOnConfiguration");
            DropTable("dbo.FollowTopic");
            DropTable("dbo.Topic");
            DropTable("dbo.Attachment");
            DropTable("dbo.Post");
            DropTable("dbo.Group");
            DropTable("dbo.ForumAccess");
            DropTable("dbo.ForumUser");
            DropTable("dbo.FollowForum");
            DropTable("dbo.Forum");
            DropTable("dbo.Category");
            DropTable("dbo.Board");
            DropTable("dbo.AccessMask");
        }
    }
}
