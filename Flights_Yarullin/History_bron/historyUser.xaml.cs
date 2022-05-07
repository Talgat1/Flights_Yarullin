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
using Flights_Yarullin.AirTicket;
using Flights_Yarullin.Reis;


namespace Flights_Yarullin.History_bron
{
    /// <summary>
    /// Логика взаимодействия для historyUser.xaml
    /// </summary>
    public partial class historyUser : Window
    {
        public historyUser()
        {
            //int b = 0;
            InitializeComponent();
            foreach (var airti in MainWindow.db.Airticket)
            {
                if (airti.Id_user == MainWindow.authUser.Id_user)
                {                     
                    dataGridTicket.ItemsSource = MainWindow.db.Airticket.Where(c => c.Id_user == MainWindow.authUser.Id_user).ToList();
                    //dataGridTicket.ItemsSource = MainWindow.db.Flight.ToList();
                    //dataGridReis.ItemsSource = MainWindow.db.Flight.Where(c => c.Dispatch_city.ToLower() == Poisk1.Text.ToLower() && c.Arrival_city.ToLower() == Poisk2.Text.ToLower()).ToList();
                }
            }
            ///dataGridTicket.ItemsSource = MainWindow.db.Flight.ToList();
        }

        private void dataGridTicket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int b = 0;
            var ggg = dataGridTicket.SelectedItem as db.Airticket;
            //MainWindow.flightUser = (db.Flight)dataGrid1.SelectedItem;
            foreach(var ff in MainWindow.db.Airticket)
            {
                if(ggg.Id_airticket == ff.Id_airticket && ggg.Id_user == MainWindow.authUser.Id_user && b == 0)
                {
                    ff.Id_user = null;
                } 
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Бронь снята.");
            
            this.Close();


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
            reis fl = new reis();
            this.Close();
            fl.Show();
        }
    }
}
