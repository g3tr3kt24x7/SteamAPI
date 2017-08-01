namespace SteamAPIWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DotaHeroes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DotaHeroes", "hero_image_sb", c => c.String());
            AddColumn("dbo.DotaHeroes", "hero_image_lg", c => c.String());
            AddColumn("dbo.DotaHeroes", "hero_image_full", c => c.String());
            AddColumn("dbo.DotaHeroes", "hero_image_vert", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DotaHeroes", "hero_image_vert");
            DropColumn("dbo.DotaHeroes", "hero_image_full");
            DropColumn("dbo.DotaHeroes", "hero_image_lg");
            DropColumn("dbo.DotaHeroes", "hero_image_sb");
        }
    }
}
