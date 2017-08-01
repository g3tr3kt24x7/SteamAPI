namespace SteamAPIWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DotaItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DotaItems", "item_image_sb", c => c.String());
            AddColumn("dbo.DotaItems", "item_image_lg", c => c.String());
            AddColumn("dbo.DotaItems", "item_image_full", c => c.String());
            AddColumn("dbo.DotaItems", "item_image_vert", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DotaItems", "item_image_vert");
            DropColumn("dbo.DotaItems", "item_image_full");
            DropColumn("dbo.DotaItems", "item_image_lg");
            DropColumn("dbo.DotaItems", "item_image_sb");
        }
    }
}
