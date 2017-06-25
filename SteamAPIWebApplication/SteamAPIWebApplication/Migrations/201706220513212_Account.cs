namespace SteamAPIWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SteamId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SteamId");
        }
    }
}
