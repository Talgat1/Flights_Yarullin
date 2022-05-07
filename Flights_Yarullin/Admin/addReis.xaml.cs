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
    /// Логика взаимодействия для addReis.xaml
    /// </summary>
    public partial class addReis : Window
    {
        string selectedText;
        string selectedText1;
        int aiplane1 = 0;
        int ailane1 = 0;
        public addReis()
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

        private void Airplane_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (airplane.SelectedItem != null)
            {
                //ComboBoxItem cbi1 = (ComboBoxItem)(sender as ComboBox).SelectedItem;
                ComboBoxItem cbi = (ComboBoxItem)airplane.SelectedItem;
                selectedText = cbi.Content.ToString();
                if (selectedText == "АН-2")
                {
                    aiplane1 = 500001;
                }
                if (selectedText == "СУ-76")
                {
                    aiplane1 = 500002;
                } 
            }
        }

        private void Airlane_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (airlane.SelectedItem != null)
            {
                //ComboBoxItem cbi1 = (ComboBoxItem)(sender as ComboBox).SelectedItem;
                ComboBoxItem cbi = (ComboBoxItem)airlane.SelectedItem;
                selectedText1 = cbi.Content.ToString();
                if (selectedText1 == "Пегас")
                {
                    ailane1 = 200001;
                }
                if (selectedText1 == "Крылья")
                {
                    ailane1 = 200002;
                }
            }
        }

        private void Button_ClickRegis(object sender, RoutedEventArgs e)
        {
            if (Data_ot.Text == "" || Data_pr.Text == "" || City_ot.Text == "" || City_pr.Text == "" || ailane1 == 0 || aiplane1 == 0)
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Flight ff = new Flight();
                ff.Arrival_city = City_pr.Text;
                ff.Arrival_date_time = Convert.ToDateTime(Data_pr.Text);
                ff.Departure_date_time = Convert.ToDateTime(Data_ot.Text);
                ff.Dispatch_city = City_ot.Text;
                ff.Id_airlinee = 200001;
                ff.Id_airplanee = 500001;
                MainWindow.db.Flight.Add(ff);
                try
                {
                    MainWindow.db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                    return;
                }

                finally
                {

                    MessageBox.Show("Успешно добавлено!");
                    adminWindow minwin = new adminWindow();
                    this.Close();
                    minwin.Show();
                }
                
                

                //MainWindow.db.Сustomer.Add(customer);


            }
        }

        private void Button_ClickNazad(object sender, RoutedEventArgs e)
        {
            adminWindow minwin = new adminWindow();
            this.Close();
            minwin.Show();
        }
    }
}
