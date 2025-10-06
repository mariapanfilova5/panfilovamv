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
using System.Data.Entity;

namespace panfilovamv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new panfilovabdEntities())
            {
                var user = context.Users.FirstOrDefault(vasya => vasya.username == loginName.Text && vasya.password == passwordName.Password);
                if (user != null)
                {
                    if (user.role == "admin")
                    {
                        var adminWindow = new Admin();
                        adminWindow.Show();
                        this.Close();
                    }
                    else if (user.role == "user")
                    {
                        MessageBox.Show("Вы успешно авторизовались");
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверный логин или пароль.Пожалуйста проверьте ещё раз введенные данные");
                    }
                }
                else
                {
                    MessageBox.Show("Вы заблокированы. Обратитесь к администратору");
                }



            }
        }
    }
}
