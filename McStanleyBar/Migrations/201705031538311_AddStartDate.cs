namespace McStanleyBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EndTime", c => c.DateTime());
            DropColumn("dbo.Events", "StartDate");
        }
    }
}
