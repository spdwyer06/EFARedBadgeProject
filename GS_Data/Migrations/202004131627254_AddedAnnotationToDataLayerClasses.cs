namespace GS_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotationToDataLayerClasses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "GameTitle", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false));
            AlterColumn("dbo.PostReplies", "ReplyContent", c => c.String(nullable: false));
            AlterColumn("dbo.Threads", "ThreadTitle", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Threads", "ThreadTitle", c => c.String());
            AlterColumn("dbo.PostReplies", "ReplyContent", c => c.String());
            AlterColumn("dbo.Posts", "PostContent", c => c.String());
            AlterColumn("dbo.Games", "GameTitle", c => c.String(nullable: false));
        }
    }
}
