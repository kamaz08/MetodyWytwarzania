namespace Sledzto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.History", "Last", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.History", "Last");
        }
    }
}
