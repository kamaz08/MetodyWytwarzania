namespace Sledzto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optionOneTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Option", "OneTime", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Option", "OneTime");
        }
    }
}
