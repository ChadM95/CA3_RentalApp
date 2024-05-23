using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CA3_RentalApp
{
    public class RentalBookingData : DbContext
    {
        //constructor base call
        public RentalBookingData() : base("RentalBookingData") { }

        //define tables
        public DbSet<Surfboard> Surfboards { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
