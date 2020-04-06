namespace GS_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPriceToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GameTitle", c => c.String(nullable: false));
            AddColumn("dbo.Games", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Games", "GameName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameName", c => c.String(nullable: false));
            DropColumn("dbo.Games", "Price");
            DropColumn("dbo.Games", "GameTitle");
        }
    }
}
