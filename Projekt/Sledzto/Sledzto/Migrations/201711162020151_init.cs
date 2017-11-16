namespace Sledzto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WebsiteId = c.Int(nullable: false),
                        TrackigTechnique = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Website", t => t.WebsiteId)
                .Index(t => t.WebsiteId);
            
            CreateTable(
                "dbo.Website",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Name = c.String(),
                        Frequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        WebsiteId = c.Int(nullable: false),
                        MessageType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Website", t => t.WebsiteId)
                .Index(t => t.WebsiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "WebsiteId", "dbo.Website");
            DropForeignKey("dbo.Option", "WebsiteId", "dbo.Website");
            DropIndex("dbo.User", new[] { "WebsiteId" });
            DropIndex("dbo.Option", new[] { "WebsiteId" });
            DropTable("dbo.User");
            DropTable("dbo.Website");
            DropTable("dbo.Option");
        }
    }
}
