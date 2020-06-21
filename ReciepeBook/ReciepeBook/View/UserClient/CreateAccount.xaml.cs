using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
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
using System.Xml.Serialization;

namespace ReciepeBook.View.UserClient
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }
        static readonly int port = 2020;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbEmail.Text) && !String.IsNullOrEmpty(tbPassword.Text) && !String.IsNullOrEmpty(tbPhoneNumber.Text)
                && !String.IsNullOrEmpty(tbName.Text) && !String.IsNullOrEmpty(tbSurname.Text))
            {
                User user = new User()
                {
                    Email = tbEmail.Text,
                    Password = tbPassword.Text,
                    PhoneNumber = tbPhoneNumber.Text,
                    Name = tbName.Text,
                    Surname = tbSurname.Text
                };
                    TcpClient client = new TcpClient();
                try
                {
                    client.Connect("127.0.0.1", port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(Encoding.UTF8.GetBytes("CU"), 0, 2);
                        XmlSerializer xmlSerializer = new XmlSerializer(user.GetType());
                        xmlSerializer.Serialize(stream, user);
                    }
                    MessageBox.Show("Аккаунт створений успішно", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
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
            }
            else
            {
                MessageBox.Show("Не всі поля заповнені коректно", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
}
