namespace GS_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDToReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "UserID");
        }
    }
}
