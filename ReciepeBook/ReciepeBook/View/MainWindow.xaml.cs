using ReciepeBook.View.UserClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReciepeBook.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Islogin { get; set; } = false;
        public User LogginedUser { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 11; i++)
                comboBoxRating.Items.Add(i);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox3.IsChecked == false)
                tb1.Text = null;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Islogin)
            {
                LoginUser loginUser = new LoginUser();
                loginUser.ShowDialog();
                Islogin = loginUser.isLoggined;
                LogginedUser = loginUser.User;
                if (Islogin)
                {
                    UserWindow window = new UserWindow(LogginedUser);
                    window.ShowDialog();
                }
            }
            else
            {
                UserWindow window = new UserWindow(LogginedUser);
                window.ShowDialog();

            }
           
        }

        private void btnMyAcc_Click(object sender, RoutedEventArgs e)
        {
            if (!Islogin)
            {
                LoginUser loginUser = new LoginUser();
                loginUser.ShowDialog();
                Islogin = loginUser.isLoggined;
                LogginedUser = loginUser.User;
                if (Islogin)
                {
                    UserWindow window = new UserWindow(LogginedUser);
                    window.ShowDialog();
                }
            }
            else
            {
                UserWindow window = new UserWindow(LogginedUser);
                window.ShowDialog();
            }
        }
    }
}
