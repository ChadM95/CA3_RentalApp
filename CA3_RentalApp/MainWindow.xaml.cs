using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA3_RentalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //window loaded event populates datagrids and ComboBox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create database reference
            RentalBookingData db = new RentalBookingData();

            //get all records from Surfboards table + update datagrid
            dgSurfboards.ItemsSource = db.Surfboards.ToList();

            //get all records from Bookings table + update datagrid
            dgBookings.ItemsSource = db.Bookings.ToList();

            //set combobox items and default selection
            cbx1.ItemsSource = new string[] { "All", "Shortboard", "Longboard", "Bodyboard" };
            cbx1.SelectedItem = "All";
        }

        //searches database for available items based on search criteria
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //check for nulls
            if (StartDatePicker.SelectedDate != null && EndDatePicker.SelectedDate != null)
            {
                //determine what was selected
                string typeSelected = cbx1.SelectedValue.ToString();
                DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
                DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

                
                    //database connection
                    RentalBookingData db = new RentalBookingData();

                    //query database and display results in listbox depending on search criteria
                    if (typeSelected == "All")
                    {
                        lbx1.ItemsSource = db.Surfboards.Where
                        (s => s.Bookings.All(b => b.StartDate >= endDate || b.EndDate <= startDate))
                        .ToList();
                    }

                    else
                    {
                        lbx1.ItemsSource = db.Surfboards.Where
                        (s => s.Bookings.All(b => b.StartDate >= endDate || b.EndDate <= startDate) && s.Type == typeSelected)
                        .ToList();
                    }
            }

            //control if a value is not entered
            else
                MessageBox.Show("Please enter a value for each option");    
        }

        //displays selected item information
        private void lbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //determine what was selected
                var selectedItem = lbx1.SelectedItem as Surfboard;
                DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
                DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

            if (selectedItem != null)
            {
                //display text information
                tblkHeading.Text = "Selected Item";
                tblkBody.Text = string.Format("Type: {0}\nStart Date: {1}\nEnd Date: {2}",
                            selectedItem.Type.ToString(), startDate.ToShortDateString(), endDate.ToShortDateString());

                //display picture for item
                switch (selectedItem.Type)
                {
                    case "Shortboard":
                        img1.Source = new BitmapImage(new Uri("pack://application:,,,/Content/shortboard.png"));
                        break;
                    case "Longboard":
                        img1.Source = new BitmapImage(new Uri("pack://application:,,,/Content/longboard.png"));
                        break;
                    case "Bodyboard":
                        img1.Source = new BitmapImage(new Uri("pack://application:,,,/Content/bodyboard.png"));
                        break;
                }

                //make book button visible
                btnBook.Visibility = Visibility.Visible;
            }
        }

        //updates the displayed start date if changed while an item is displayed
        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbx1.SelectedItem != null)
            {
                //determine what is selected
                var selectedItem = lbx1.SelectedItem as Surfboard;
                DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
                DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

                //update text information
                tblkHeading.Text = "Selected Item";
                tblkBody.Text = string.Format("Type: {0}\nStart Date: {1}\nEnd Date: {2}",
                            selectedItem.Type.ToString(), startDate.ToShortDateString(), endDate.ToShortDateString());

            }
        }
        
        //updates the displayed end date if changed while an item is displayed
        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbx1.SelectedItem != null)
            {
                //determine what is selected
                var selectedItem = lbx1.SelectedItem as Surfboard;
                DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
                DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

                //update text information
                tblkHeading.Text = "Selected Item";
                tblkBody.Text = string.Format("Type: {0}\nStart Date: {1}\nEnd Date: {2}",
                            selectedItem.Type.ToString(), startDate.ToShortDateString(), endDate.ToShortDateString());

            }
        }

        //adds a new booking to the database
        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            //determine selected fields
            string typeSelected = lbx1.SelectedValue.ToString();
            DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
            DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

            //create database reference
            RentalBookingData db = new RentalBookingData();

            //if statement starts here

                //create new object // dates, surfboard type, surfboard id
                Booking b1 = new Booking
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    SurfboardId = db.Surfboards.Where(s => s.Type == typeSelected)
                                                .Select(s => s.SurfboardId)
                                                .FirstOrDefault(),
                    //Surfboard = db.Surfboards.Where(s => s.Type == typeSelected)
                    //                            .Select(s => s.Type)
                    //                            .FirstOrDefault()
                };

                //add object to db
                db.Bookings.Add(b1);
                db.SaveChanges();

            //add booking the surfboards bookings collection
            var surfboard = db.Surfboards.Include(s => s.Bookings).FirstOrDefault(s => s.SurfboardId == b1.SurfboardId);

            if (surfboard != null)
            {
                surfboard.Bookings.Add(b1); // Add the booking to the Surfboard's Bookings collection

                // Save changes to the database
                db.SaveChanges();
            }
        

            //refresh bookings datagrid
            dgBookings.ItemsSource = db.Bookings.ToList();

            //display message
            MessageBox.Show("Booking Successful");

            //else
            //MessageBox.Show("Cannot book this item for the selected dates");
        }
    }
}