namespace CA3_RentalApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CA3_RentalApp.RentalBookingData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CA3_RentalApp.RentalBookingData";
        }

        protected override void Seed(CA3_RentalApp.RentalBookingData context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
