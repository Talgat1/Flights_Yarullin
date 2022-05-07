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

namespace Flights_Yarullin.Registration
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void Button_ClickRegis(object sender, RoutedEventArgs e)
        {
            if (SurnameTB.Text == "" || NameTB.Text == "" || PhoneTB.Text == "" || PasswordTB.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                int b = 0;
                db.User user = new db.User();
                user.Surname = SurnameTB.Text;
                user.Name = NameTB.Text;
                user.Phone = PhoneTB.Text;
                user.Password = PasswordTB.Text;
                user.Id_role = 2;
                foreach (var tt in MainWindow.db.User)
                {
                    if (tt.Phone == PhoneTB.Text)
                    {
                        b++;
                        MessageBox.Show("Такой номер телефона уже зарегистрирован, введите другой номер");
                    }
                }

                if (b == 0)
                {
                    MainWindow.db.User.Add(user);
                    MainWindow.db.SaveChanges();
                    MainWindow minwin = new MainWindow();
                    this.Close();
                    minwin.Show();
                }

                //MainWindow.db.Сustomer.Add(customer);


            }
        }

        private void Button_ClickNazad(object sender, RoutedEventArgs e)
        {
            MainWindow minwin = new MainWindow();
            this.Close();
            minwin.Show();
        }
    }
}
