namespace McStanleyBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeCreated = c.DateTime(nullable: false),
                        Fulfilled = c.Boolean(nullable: false),
                        Location = c.String(),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderEvents",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Events_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Events_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Events_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Events_Id);
            
            AddColumn("dbo.Events", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderEvents", "Events_Id", "dbo.Events");
            DropForeignKey("dbo.OrderEvents", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderEvents", new[] { "Events_Id" });
            DropIndex("dbo.OrderEvents", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropColumn("dbo.Events", "Price");
            DropTable("dbo.OrderEvents");
            DropTable("dbo.Orders");
        }
    }
}
