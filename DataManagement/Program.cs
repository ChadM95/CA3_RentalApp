using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CA3_RentalApp;

namespace DataManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create database reference
            RentalBookingData db = new RentalBookingData();

            using (db)
            {
                ////delete all bookings
                //var allBookings = db.Bookings.ToList();
                //db.Bookings.RemoveRange(allBookings);


                ////create new objects
                //Surfboard s1 = new Surfboard { Type = "Shortboard" };
                //Surfboard s2 = new Surfboard { Type = "Longboard" };
                //Surfboard s3 = new Surfboard { Type = "Bodyboard" };

                ////add to database
                //db.Surfboards.Add(s1);
                //db.Surfboards.Add(s2);
                //db.Surfboards.Add(s3);

                //save changes
                db.SaveChanges();
            }

            Console.WriteLine("Finished!");
           
            Console.ReadLine();
        }
    }
}
