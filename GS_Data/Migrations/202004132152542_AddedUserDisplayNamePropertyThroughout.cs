namespace GS_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserDisplayNamePropertyThroughout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CreatorDisplayName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Posts", "CreatorDisplayName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.PostReplies", "CreatorDisplayName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Threads", "CreatorDisplayName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DisplayName");
            DropColumn("dbo.Threads", "CreatorDisplayName");
            DropColumn("dbo.PostReplies", "CreatorDisplayName");
            DropColumn("dbo.Posts", "CreatorDisplayName");
            DropColumn("dbo.Reviews", "CreatorDisplayName");
        }
    }
}
