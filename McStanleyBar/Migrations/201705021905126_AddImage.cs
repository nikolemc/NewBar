namespace McStanleyBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Img");
        }
    }
}
