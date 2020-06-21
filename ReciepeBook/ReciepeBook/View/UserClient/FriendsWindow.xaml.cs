using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
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
    /// Interaction logic for FriendsWindow.xaml
    /// </summary>
    public partial class FriendsWindow : Window
    {
        public User User { get; set; }
        public ObservableCollection<Friend> Friends { get; set; }
        = new ObservableCollection<Friend>();
        public FriendsWindow(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = this;
            GetFriends();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbEmail.Text))
            {
                const int port = 2020;
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect("127.0.0.1", port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(Encoding.UTF8.GetBytes("AF"), 0, 2);
                        stream.Write(Encoding.UTF8.GetBytes(tbEmail.Text), 0, tbEmail.Text.Length);
                        const int BufferSize = 6;
                        byte[] commandResponce = new byte[BufferSize];
                        stream.Read(commandResponce, 0, BufferSize);
                        int userId = Convert.ToInt32(Encoding.UTF8.GetString(commandResponce));

                        if (userId >= 0)
                        {
                            stream.Write(Encoding.UTF8.GetBytes(User.Email), 0, User.Email.Length);
                            GetFriends();
                        }
                        else
                        {
                            MessageBox.Show("Невірні дані користувача", "", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
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
            }
            else
            {
                MessageBox.Show("Введіть e-mail друга", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void GetFriends()
        {

            const int port = 2020;
            TcpClient client = new TcpClient();
            try
            {
                client.Connect("127.0.0.1", port);
                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(Encoding.UTF8.GetBytes("GF"), 0, 2);
                    stream.Write(Encoding.UTF8.GetBytes(User.Email), 0, User.Email.Length);
                    XmlSerializer xml = new XmlSerializer(typeof(List<Friend>));
                    List<Friend> friends = (List<Friend>)xml.Deserialize(stream);
                    Friends.Clear();
                    foreach (var item in friends)
                    {
                        Friends.Add(item);
                    }
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
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                const int port = 2020;
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect("127.0.0.1", port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(Encoding.UTF8.GetBytes("DF"), 0, 2);
                        string id = Friends[list.SelectedIndex].Friend1Id.ToString();
                        stream.Write(Encoding.UTF8.GetBytes(id), 0, id.Length);
                        XmlSerializer xml = new XmlSerializer(typeof(List<Friend>));
                        GetFriends();
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
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                SendMessageWindow window = new SendMessageWindow(User, Friends[list.SelectedIndex].User1.Email);
                window.Show();
            }
        }
    }

}
