namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CargoVolume = c.Int(nullable: false),
                        CargoWeight = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CargoId = c.Int(nullable: false),
                        Source = c.String(),
                        Destination = c.String(),
                        ShippingDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cargoes", t => t.CargoId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.CargoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Shipments", "CargoId", "dbo.Cargoes");
            DropForeignKey("dbo.Cargoes", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Cargoes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Shipments", new[] { "CargoId" });
            DropIndex("dbo.Shipments", new[] { "CustomerId" });
            DropIndex("dbo.Cargoes", new[] { "CustomerId" });
            DropIndex("dbo.Cargoes", new[] { "WarehouseId" });
            DropTable("dbo.Shipments");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Customers");
            DropTable("dbo.Cargoes");
        }
    }
}
