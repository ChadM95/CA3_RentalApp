namespace CA3_RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Haventaclue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "Surfboard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Surfboard", c => c.String());
        }
    }
}
