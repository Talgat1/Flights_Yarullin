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
            NameTB.Text = MainWindow.authUser.Name;
            //Number_reis.Text = MainWindow.flightUser.Id_flight.ToString();
            Number_reis.Text = flightt.Id_flight.ToString();
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
    }
}
