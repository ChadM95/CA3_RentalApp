namespace CA3_RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedBookingCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Surfboards", "BookingCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surfboards", "BookingCount", c => c.Int(nullable: false));
        }
    }
}
