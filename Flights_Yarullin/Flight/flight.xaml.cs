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
using Flights_Yarullin.AirTicket;
using Flights_Yarullin.Flight;
using Flights_Yarullin.History_bron;

namespace Flights_Yarullin.Flight
{
    /// <summary>
    /// Логика взаимодействия для flight.xaml
    /// </summary>
    public partial class flight : Window
    {
        int b = 0;
        public flight()
        {
            InitializeComponent();
            if(b == 0)
            {         
                dataGridReis.ItemsSource = MainWindow.db.Flight.ToList();         
            }            
            //var gg = MainWindow.db.Flight.Where(c => c.Dispatch_city.ToLower() == "Омск".ToLower()).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            foreach (var flig in MainWindow.db.Flight)
            {
                if (flig.Arrival_city == Poisk1.Text.Trim() && flig.Dispatch_city == Poisk2.Text.Trim())
                {                   
                    b++;
                    /*var query =
                    from us in MainWindow.db.Flight
                    where us.Dispatch_city == Poisk1.Text.Trim() && us.Arrival_city == Poisk2.Text.Trim()
                    orderby us.Airline.Name_arline
                    select new {us.Id_flight, us.Dispatch_city, us.Arrival_city, us.Departure_date_time, us.Arrival_date_time, us.Airline.Name_arline  };
                    dataGrid1.ItemsSource = query.ToList();*/
                    dataGridReis.ItemsSource = MainWindow.db.Flight.Where(c => c.Dispatch_city.ToLower() == Poisk1.Text.ToLower() && c.Arrival_city.ToLower() == Poisk2.Text.ToLower()) .ToList();                              
                }
            }
            if (b == 0)
            {
                MessageBox.Show("Нет такого рейса!Возможно вы неверно написали название название города!");
            }                                    
        }       
        private void dataGridReis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {                                
            var ggg = dataGridReis.SelectedItem as db.Flight;
            //MainWindow.flightUser = (db.Flight)dataGrid1.SelectedItem;
            airticket air = new airticket(ggg);
            this.Close();
            air.Show();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            historyUser hs = new historyUser();
            this.Close();
            hs.Show();
        }
    }
}
