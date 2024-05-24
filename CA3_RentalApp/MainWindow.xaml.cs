using System;
using System.Collections.Generic;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //database reference
            RentalBookingData db = new RentalBookingData();

            //get all records from Surfboards table
            var query = db.Surfboards.ToList();

            //update surfboards datagrid to show all items
            dgSurfboards.ItemsSource = query;

            //set combobox items and default selection
            cbx1.ItemsSource = new string[] { "All", "Shortboard", "Longboard", "Bodyboard" };
            cbx1.SelectedItem = "All";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
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

            private void lbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //determine what was selected
                var selectedItem = lbx1.SelectedItem as Surfboard;
                DateTime startDate = (DateTime)StartDatePicker.SelectedDate;
                DateTime endDate = (DateTime)EndDatePicker.SelectedDate;

                //display text information
                tblk1.Text = string.Format("<b>Selected Item</b>\nType: {0}\nStart Date: {1}\nEnd Date: {2}",
                            selectedItem.Type.ToString(), startDate.ToShortDateString(), endDate.ToShortDateString());

                //display picture
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
    }