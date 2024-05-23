namespace CA3_RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SurfboardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Surfboards", t => t.SurfboardId, cascadeDelete: true)
                .Index(t => t.SurfboardId);
            
            CreateTable(
                "dbo.Surfboards",
                c => new
                    {
                        SurfboardId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Bookings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SurfboardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "SurfboardId", "dbo.Surfboards");
            DropIndex("dbo.Bookings", new[] { "SurfboardId" });
            DropTable("dbo.Surfboards");
            DropTable("dbo.Bookings");
        }
    }
}
