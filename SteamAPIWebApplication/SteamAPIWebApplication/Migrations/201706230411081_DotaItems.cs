namespace SteamAPIWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DotaItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DotaItems",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        cost = c.String(),
                        secret_shop = c.String(),
                        side_shop = c.String(),
                        recipe = c.String(),
                        localized_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DotaItems");
        }
    }
}
