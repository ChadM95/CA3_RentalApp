using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CA3_RentalApp
{
    public class Booking
    {
        //core properties
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //foreign key relationship
        public int SurfboardId { get; set; }

        //navigation reference to access Surfboard 
        public string Surfboard { get; set; }
    }
}
