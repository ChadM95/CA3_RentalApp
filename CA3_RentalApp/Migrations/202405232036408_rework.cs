namespace CA3_RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rework : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surfboards", "BookingCount", c => c.Int(nullable: false));
            DropColumn("dbo.Surfboards", "Bookings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surfboards", "Bookings", c => c.Int(nullable: false));
            DropColumn("dbo.Surfboards", "BookingCount");
        }
    }
}
