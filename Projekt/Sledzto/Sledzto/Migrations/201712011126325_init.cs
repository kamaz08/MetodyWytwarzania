namespace Sledzto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        OptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Option", t => t.OptionId)
                .Index(t => t.OptionId);
            
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WebsiteId = c.Int(nullable: false),
                        TrackigTechnique = c.Int(nullable: false),
                        Options = c.String(),
                        Frequency = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        OptionId = c.Int(nullable: false),
                        MessageType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Option", t => t.OptionId)
                .Index(t => t.OptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "OptionId", "dbo.Option");
            DropForeignKey("dbo.Option", "WebsiteId", "dbo.Website");
            DropForeignKey("dbo.History", "OptionId", "dbo.Option");
            DropIndex("dbo.User", new[] { "OptionId" });
            DropIndex("dbo.Option", new[] { "WebsiteId" });
            DropIndex("dbo.History", new[] { "OptionId" });
            DropTable("dbo.User");
            DropTable("dbo.Website");
            DropTable("dbo.Option");
            DropTable("dbo.History");
        }
    }
}
