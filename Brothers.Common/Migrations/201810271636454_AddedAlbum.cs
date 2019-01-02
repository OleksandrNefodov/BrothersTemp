namespace Brothers.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Photos", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.Videos", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "AlbumId");
            CreateIndex("dbo.Videos", "AlbumId");
            AddForeignKey("dbo.Photos", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Videos", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Photos", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Videos", new[] { "AlbumId" });
            DropIndex("dbo.Photos", new[] { "AlbumId" });
            DropColumn("dbo.Videos", "AlbumId");
            DropColumn("dbo.Photos", "AlbumId");
            DropTable("dbo.Albums");
        }
    }
}
