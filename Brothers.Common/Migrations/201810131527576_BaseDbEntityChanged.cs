namespace Brothers.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseDbEntityChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Videos", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Photos", "Types");
            DropColumn("dbo.Videos", "Types");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Types", c => c.Int(nullable: false));
            AddColumn("dbo.Photos", "Types", c => c.Int(nullable: false));
            DropColumn("dbo.Videos", "Type");
            DropColumn("dbo.Photos", "Type");
        }
    }
}
