using ReciepeBook.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public ObservableCollection<Message> Messages { get; set; } =
            new ObservableCollection<Message>();

        public User User { get; set; }
        static readonly int port = 2020;
        public UserWindow(User user)
        {
            InitializeComponent();
            User = user;
            tbName.Text = User.Name + "  " + user.Surname;
            DataContext = this;
            ShowMessages();
           
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                Reciepe reciepe = Messages[list.SelectedIndex].Reciepe;
                    Model.Reciepe NewReciepe= new Model.Reciepe()
                    {
                        ReciepeName = reciepe.ReciepeName,
                        Ingredients = reciepe.Ingredients,
                        PhotoPath = reciepe.PhotoPath,
                        Instruction = reciepe.Instruction,
                        CookingTime = reciepe.CookingTime,
                        Calories = reciepe.Calories,
                        CuisineId = reciepe.Cuisine.Id,
                        TypeId = reciepe.ReciepeType.Id,
                        Rating = reciepe.Raiting,
                    };
                try
                {
                    ReciepeBookHelper.dbReciepe.Reciepe.Add(NewReciepe);
                    ReciepeBookHelper.dbReciepe.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    MessageBox.Show("У вас вже є такий рецепт", "Неможливо добавити",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient();
            if (list.SelectedIndex >= 0)
            {
                try
                {
                    client.Connect("127.0.0.1", port);

                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(Encoding.UTF8.GetBytes("DM"), 0, 2);
                        stream.Write(Encoding.UTF8.GetBytes(Messages[list.SelectedIndex].Id.ToString()), 0, Messages[list.SelectedIndex].Id.ToString().Length);
                        Thread.Sleep(50);
                        ShowMessages();
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
        private void ShowMessages()
        {
            List<Message> messages = new List<Message>();
            TcpClient client = new TcpClient();
            try
            {
                client.Connect("127.0.0.1", port);

                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(Encoding.UTF8.GetBytes("GM"), 0, 2);
                    stream.Write(Encoding.UTF8.GetBytes(User.Email), 0, User.Email.Length);
                    Thread.Sleep(50);
                    XmlSerializer xml = new XmlSerializer(messages.GetType());
                    messages = (List<Message>)xml.Deserialize(stream);

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
            Messages.Clear();
            foreach (var item in messages)
            {
                Messages.Add(item);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                ShowMessageWindow window = new ShowMessageWindow(Messages[list.SelectedIndex]);
                window.Show();
            }
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (list.SelectedIndex >= 0)
            {
                ShowMessageWindow window = new ShowMessageWindow(Messages[list.SelectedIndex]);
                window.Show();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages();
        }

        private void btnNewMessage_Click(object sender, RoutedEventArgs e)
        {
            SendMessageWindow window = new SendMessageWindow(User,"");
            window.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FriendsWindow friendsWindow = new FriendsWindow(User);
            friendsWindow.Show();
        }
    }
}
