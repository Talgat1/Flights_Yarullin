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

namespace Flights_Yarullin.Admin
{
    /// <summary>
    /// Логика взаимодействия для adminWindow.xaml
    /// </summary>
    public partial class adminWindow : Window
    {
        public adminWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void add_user_Click(object sender, RoutedEventArgs e)
        {
            userAdd addus = new userAdd();
            this.Close();
            addus.Show();
        }

        private void add_reis_Click(object sender, RoutedEventArgs e)
        {
            addReis ar = new addReis();
            this.Close();
            ar.Show();
        }

        private void delete_user_Click(object sender, RoutedEventArgs e)
        {
            userDelete ud = new userDelete();
            this.Close();
            ud.Show();
        }

        private void delete_reis_Click(object sender, RoutedEventArgs e)
        {
            deleteReis dr = new deleteReis();
            this.Close();
            dr.Show();
        }
    }
}
