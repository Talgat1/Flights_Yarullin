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
using System.Windows.Shapes;
using Flights_Yarullin.db;
using Flights_Yarullin.Flight;

namespace Flights_Yarullin.AirTicket
{
    /// <summary>
    /// Логика взаимодействия для airticket.xaml
    /// </summary>
    public partial class airticket : Window
    {
        
        public airticket(db.Flight flightt)
        {
            InitializeComponent();
            //Class_air.ItemsSource = FlightsEntities.GetContext().TypeAirticket.ToList();
            NameTB.Text = MainWindow.authUser.Name;
            //Number_reis.Text = MainWindow.flightUser.Id_flight.ToString();
            Number_reis.Text = flightt.Id_flight.ToString();
            Vilet.Text = flightt.Departure_date_time.ToString();
            Prilet.Text = flightt.Arrival_date_time.ToString();
            aviakomp.Text = flightt.Airline.Name_arline.ToString();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void reis_Click(object sender, RoutedEventArgs e)
        {
            flight fl = new flight();
            this.Close();
            fl.Show();            
        }

        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
             if(Class_air.SelectedItem != null)
             {
                //ComboBoxItem cbi1 = (ComboBoxItem)(sender as ComboBox).SelectedItem;
                ComboBoxItem cbi = (ComboBoxItem)Class_air.SelectedItem;
                string selectedText = cbi.Content.ToString();
                if(selectedText == "item1")
                {
                    Price.Text = "1500р";
                    foreach (var airtic in MainWindow.db.Airticket)
                    {
                        if(airtic.Id_type_airticket == 2200001 && airtic.Id_booking == 400002 && airtic.Id_flight.ToString() == Number_reis.Text)
                        {
                            Place.Text = airtic.Place;
                        }
                    }
                }
            }

        }

        
    }
}
