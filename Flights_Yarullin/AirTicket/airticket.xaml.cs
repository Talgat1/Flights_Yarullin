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
        string selectedText;
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
                selectedText = cbi.Content.ToString();
                if(selectedText == "Бизнесс класс")
                {
                    int b = 0;
                    //Price.Text = "1500р";
                    foreach (var airtic in MainWindow.db.Airticket)
                    {
                        if(airtic.Id_type_airticket == 2200001 && airtic.Id_user == null && airtic.Id_booking == 400001 && airtic.Id_flight.ToString() == Number_reis.Text && b == 0)
                        {
                            b++;
                            Place.Text = airtic.Place;
                            Price.Text = airtic.Price;
                            
                        }
                    }
                    if (b == 0)
                    {
                        MessageBox.Show("Все билеты бизнесс класса забронированы!");
                    }
                }
                if (selectedText == "Эконом класс")
                {
                    int b = 0;
                    //Price.Text = "1500р";
                    foreach (var airtic in MainWindow.db.Airticket)
                    {
                        if (airtic.Id_type_airticket == 2200002 && airtic.Id_user == null && airtic.Id_booking == 400001 && airtic.Id_flight.ToString() == Number_reis.Text && b == 0)
                        {
                            b++;
                            Place.Text = airtic.Place;
                            Price.Text = airtic.Price;

                        }
                    }
                    if (b == 0)
                    {
                        MessageBox.Show("Все билеты эконом класса забронированы!");
                    }
                }
                if (selectedText == "Первый класс")
                {
                    int b = 0;
                    //Price.Text = "1500р";
                    foreach (var airtic in MainWindow.db.Airticket)
                    {
                        if (airtic.Id_type_airticket == 2200003 && airtic.Id_user == null && airtic.Id_booking == 400001 && airtic.Id_flight.ToString() == Number_reis.Text && b == 0)
                        {
                            b++;
                            Place.Text = airtic.Place;
                            Price.Text = airtic.Price;

                        }
                    }
                    if (b == 0)
                    {
                        MessageBox.Show("Все билеты первого класса забронированы!");
                    }
                }
            }

        }

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            int b = 0;
            if(selectedText == "Бизнесс класс")
            {
                foreach (var airtic in MainWindow.db.Airticket)
                {
                    if (airtic.Id_type_airticket == 2200001 && airtic.Id_user == null && airtic.Id_booking == 400001 && airtic.Id_flight.ToString() == Number_reis.Text && b == 0)
                    {
                        b++;                                             
                        airtic.Id_user = MainWindow.authUser.Id_user;
                        airtic.Id_booking = 400002;                       
                        //airt.Id_user = airtic.Id_user;
                        //airt.Id_booking = airtic.Id_booking;

                    }
                }                
            }
            if (selectedText == "Эконом класс")
            {
                foreach (var airtic in MainWindow.db.Airticket)
                {
                    if (airtic.Id_type_airticket == 2200002 && airtic.Id_user == null && airtic.Id_booking == 400001 && airtic.Id_flight.ToString() == Number_reis.Text && b == 0)
                    {
                        b++;
                        airtic.Id_user = MainWindow.authUser.Id_user;
                        airtic.Id_booking = 400002;
                        //airt.Id_user = airtic.Id_user;
                        //airt.Id_booking = airtic.Id_booking;

                    }
                }
            }
            if (selectedText == "Первый класс")
            {
                foreach (var airtic in MainWindow.db.Airticket)
                {
                    if (airtic.Id_type_airticket == 2200003 && airtic.Id_user == null && airtic.Id_booking == 400001 && airtic.Id_flight.ToString() == Number_reis.Text && b == 0)
                    {
                        b++;
                        airtic.Id_user = MainWindow.authUser.Id_user;
                        airtic.Id_booking = 400002;
                        //airt.Id_user = airtic.Id_user;
                        //airt.Id_booking = airtic.Id_booking;

                    }
                }
            }
            MainWindow.db.SaveChanges();
            MessageBox.Show("Успешно забронировано! Ваша бронь билета находится в истории бронирования.");
            flight fl = new flight();
            this.Close();
            fl.Show();
        }
    }
}
