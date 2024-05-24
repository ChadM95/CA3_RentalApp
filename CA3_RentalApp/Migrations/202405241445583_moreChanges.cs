namespace CA3_RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Surfboard", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Surfboard");
        }
    }
}
