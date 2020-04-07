namespace GS_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOwnerIDToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "OwnerId");
        }
    }
}
