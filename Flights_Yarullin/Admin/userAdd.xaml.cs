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
    /// Логика взаимодействия для userAdd.xaml
    /// </summary>
    public partial class userAdd : Window
    {
        public userAdd()
        {
            InitializeComponent();
        }

        private void Button_ClickNazad(object sender, RoutedEventArgs e)
        {
            adminWindow aw = new adminWindow();
            this.Close();
            aw.Show();
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
                
                foreach(var tt in MainWindow.db.User)
                {
                    if(tt.Phone == PhoneTB.Text)
                    {
                        b++;
                        MessageBox.Show("Такой номер телефона уже зарегистрирован, введите другой номер");
                    }
                }

                if(b == 0)
                {
                    User user = new User();
                    user.Surname = SurnameTB.Text;
                    user.Name = NameTB.Text;
                    user.Phone = PhoneTB.Text;
                    user.Password = PasswordTB.Text;
                    user.Id_role = 2;
                    MainWindow.db.User.Add(user);
                    try
                    {
                        MainWindow.db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Такой логин уже существет, введите другой");
                        return;
                    }

                    finally
                    {
                        
                        MessageBox.Show("Пользователь добавлен!");
                        MainWindow minwin = new MainWindow();
                        this.Close();
                        minwin.Show();
                    }                                      
                }
            }
        }
    }
}
