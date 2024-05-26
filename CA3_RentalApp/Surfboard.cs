using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CA3_RentalApp
{
    public class Surfboard
    {
        //properties
        public int SurfboardId { get; set; }
        public string Type { get; set; }

        //collection of bookings
        public List<Booking> Bookings { get; set; }

        //gives int value of Bookings.Count 
        public int BookingCount
        {
            get { return Bookings.Count; }    
        }

        //contructor to initialise bookings collection
        public Surfboard()
        {
            Bookings = new List<Booking>();
        }

        //override ToString method
        public override string ToString()
        {
            return string.Format("{0}",Type);
        }

    }
}
