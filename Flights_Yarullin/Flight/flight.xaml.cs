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
            var dd1 =
            from us in MainWindow.db.Flight
            orderby us.Airline.Name_arline
            select new { us.Id_flight, us.Dispatch_city, us.Arrival_city, us.Departure_date_time, us.Arrival_date_time, us.Airline.Name_arline };
            dataGrid1.ItemsSource = dd1.ToList();
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
                    //user.Phone = price.ToString().Trim();
                    b++;
                    var query =
                    from us in MainWindow.db.Flight

                    where us.Arrival_city == Poisk1.Text.Trim() && us.Dispatch_city == Poisk2.Text.Trim()
                    orderby us.Airline.Name_arline
                    select new { us.Id_flight, us.Dispatch_city, us.Arrival_city, us.Departure_date_time, us.Arrival_date_time, us.Airline.Name_arline };



                    //dataGrid1.ItemsSource = MainWindow.db.Flight.ToList();
                    dataGrid1.ItemsSource = query.ToList();

                }
            }
            if (b == 0)
            {
                MessageBox.Show("Нет такого рейса!" +
                    "Возможно вы неверно написали название название города!");
            }
        }

        

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            airticket air = new airticket();
            this.Close();
            air.Show();
        }
    }
}
