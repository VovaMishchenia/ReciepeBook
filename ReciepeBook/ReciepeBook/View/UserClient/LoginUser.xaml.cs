using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ReciepeBook.View.UserClient
{
    /// <summary>
    /// Interaction logic for LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Window
    {
        public  bool isLoggined { get; set; } = false;
        public User User { get; set; }

        public LoginUser()
        {
            InitializeComponent();
            
        }

        private void btnCreateAcc_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount create = new CreateAccount();
            create.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const int port = 2020;
            if (!String.IsNullOrEmpty(tbemail.Text) && !String.IsNullOrEmpty(tbPassword.Password))
            {
                User user = new User()
                {
                    Email = tbemail.Text,
                    Password = tbPassword.Password,
                };
                User userGet = null;
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect("127.0.0.1", port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(Encoding.UTF8.GetBytes("LU"), 0, 2);
                        stream.Write(Encoding.UTF8.GetBytes(tbemail.Text), 0, tbemail.Text.Length);
                        Thread.Sleep(50);
                        stream.Write(Encoding.UTF8.GetBytes(tbPassword.Password), 0, tbPassword.Password.Length);
                        stream.Flush();
                        Thread.Sleep(100);
                        XmlSerializer xml = new XmlSerializer(typeof(User));
                        userGet = (User)xml.Deserialize(stream);
                    }

                }
                catch (SocketException ex)
                {
                    MessageBox.Show("Неможливо приєднатись до сервера", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    client.Close();
                }
                if (userGet.Email != "none" && userGet.Password!="none")
                {
                    isLoggined = true;
                    User = userGet;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Дані користувача невірні", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
    
}
