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

namespace Flights_Yarullin.Admin
{
    /// <summary>
    /// Логика взаимодействия для deleteReis.xaml
    /// </summary>
    public partial class deleteReis : Window
    {
        int b = 0;
        public deleteReis()
        {
            InitializeComponent();
            if (b == 0)
            {
                dataGridReis.ItemsSource = MainWindow.db.Flight.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void dataGridReis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ggg = dataGridReis.SelectedItem as Flight;
            //MainWindow.flightUser = (db.Flight)dataGrid1.SelectedItem;
            foreach(var a in MainWindow.db.Flight)
            {
                if(ggg.Id_flight == a.Id_flight)
                {
                    MainWindow.db.Flight.Remove(a);
                    MessageBox.Show("Рейс удален!");

                    
                }
            }
            foreach (var a1 in MainWindow.db.Airticket)
            {
                if (ggg.Id_flight == a1.Id_flight)
                {
                    MainWindow.db.Airticket.Remove(a1);
                    MessageBox.Show("Билеты удалены!");
                }
            }
            MainWindow.db.SaveChanges();
            adminWindow aw = new adminWindow();
            this.Close();
            aw.Show();
        }
    }
}
