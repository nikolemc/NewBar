namespace McStanleyBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Events_Id", "dbo.Events");
            DropIndex("dbo.Orders", new[] { "Ticket_Id" });
            DropIndex("dbo.Orders", new[] { "Events_Id" });
            DropIndex("dbo.Tickets", new[] { "Order_Id" });
            RenameColumn(table: "dbo.Tickets", name: "EventsId", newName: "EventId");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "UserId");
            RenameIndex(table: "dbo.Tickets", name: "IX_EventsId", newName: "IX_EventId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_UserId");
            AddColumn("dbo.Tickets", "PurchasePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Tickets", "WasUsed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Ticket_Id");
            DropColumn("dbo.Orders", "Events_Id");
            DropColumn("dbo.Tickets", "Price");
            DropColumn("dbo.Tickets", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Order_Id", c => c.Int());
            AddColumn("dbo.Tickets", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Events_Id", c => c.Int());
            AddColumn("dbo.Orders", "Ticket_Id", c => c.Int());
            DropColumn("dbo.Tickets", "WasUsed");
            DropColumn("dbo.Tickets", "PurchasePrice");
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_CustomerId");
            RenameIndex(table: "dbo.Tickets", name: "IX_EventId", newName: "IX_EventsId");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "CustomerId");
            RenameColumn(table: "dbo.Tickets", name: "EventId", newName: "EventsId");
            CreateIndex("dbo.Tickets", "Order_Id");
            CreateIndex("dbo.Orders", "Events_Id");
            CreateIndex("dbo.Orders", "Ticket_Id");
            AddForeignKey("dbo.Orders", "Events_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Tickets", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Ticket_Id", "dbo.Tickets", "Id");
        }
    }
}
