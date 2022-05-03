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
using Flights_Yarullin.db;
using Flights_Yarullin.Registration;
using Flights_Yarullin.Flight;
using Flights_Yarullin.AirTicket;

namespace Flights_Yarullin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static FlightsEntities2 db = new FlightsEntities2();

        public static User authUser;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            flight fl = new flight();
            foreach (var user in MainWindow.db.User)
            {
                if (user.Phone == PhoneTB.Text.Trim())
                {
                    if (user.Password == PasswordTB.Text.Trim() && user.Id_role == 2)
                    {
                        MessageBox.Show($"Привет {user.Name}");
                        MainWindow.authUser = user;
                        //MessageBox.Show($"{MainWindow.authUser}");
                        this.Close();
                        fl.Show();
                    }
                    if (user.Password == PasswordTB.Text.Trim() && user.Id_role == 1)
                    {
                        MessageBox.Show($"Привет {user.Name}");
                        this.Close();
                        fl.Show();
                    }
                }
            }
        }

        

        private void Regis_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration();
            this.Close();
            reg.Show();
        }

        
    }
}
