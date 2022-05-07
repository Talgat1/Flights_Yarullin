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
    /// Логика взаимодействия для userDelete.xaml
    /// </summary>
    public partial class userDelete : Window
    {
       
        public userDelete()
        {
            InitializeComponent();
            foreach(var a in MainWindow.db.User)
            {
                dataGridUser.ItemsSource = MainWindow.db.User.Where(c => c.Id_role == 2).ToList();
                /*if(a.Id_user == 2)
                {
                    dataGridUser.ItemsSource = MainWindow.db.User.ToList();
                }*/
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void dataGridUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ggg = dataGridUser.SelectedItem as User;
            //MainWindow.flightUser = (db.Flight)dataGrid1.SelectedItem;
            foreach (var a in MainWindow.db.User)
            {
                if (ggg.Id_user == a.Id_user)
                {
                    MainWindow.db.User.Remove(a);
                    MessageBox.Show("Пользователь удален!");


                }
            }            
            MainWindow.db.SaveChanges();
            adminWindow aw = new adminWindow();
            this.Close();
            aw.Show();
        }
    }
}
