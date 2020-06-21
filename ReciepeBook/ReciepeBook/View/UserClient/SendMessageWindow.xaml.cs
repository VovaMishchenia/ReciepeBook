using Data_access_layer;
using Newtonsoft.Json;
using ReciepeBook.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SendMessageWindow.xaml
    /// </summary>
    public partial class SendMessageWindow : Window
    {
        User User { get; set; }
        string EmailTo { get; set; }
        public ObservableCollection<Reciepe> Reciepes { get; set; }
        = new ObservableCollection<Reciepe>();
        public SendMessageWindow(User user, string email)
        {
            InitializeComponent();
            User = user;
            EmailTo = email;
            if (!String.IsNullOrEmpty(email))
            {
                tbTo.Text = EmailTo;
            }
            foreach (var item in ReciepeBookHelper.GetReciepes())
            {
                Reciepes.Add(new Reciepe()
                {
                    Id = item.Id,
                    ReciepeName = item.ReciepeName,
                    Ingredients = item.Ingredients,
                    PhotoPath = item.PhotoPath,
                    Instruction = item.Instruction,
                    CookingTime = item.CookingTime,
                    Calories = item.Calories,
                    Raiting = (int)item.Rating,

                    Cuisine = new Cuisine()
                    {
                        Name = item.Cuisine.CuisineName,
                        Id = (int)item.CuisineId
                    },

                    ReciepeType = new ReciepeType()
                    {
                        Name = item.ReciepeType.TypeName,
                        Id = (int)item.TypeId
                    }
                });
            }
            DataContext = this;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbTo.Text) && cbReciepe.SelectedIndex >= 0)
            {
                const int port = 2020;
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect("127.0.0.1", port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(Encoding.UTF8.GetBytes("AM"), 0, 2);
                        #region AddMessage1

                        stream.Write(Encoding.UTF8.GetBytes(tbTo.Text), 0, tbTo.Text.Length);
                        stream.Flush();

                        const int BufferSize = 6;
                        byte[] commandResponce = new byte[BufferSize];
                        stream.Read(commandResponce, 0, BufferSize);
                        int userId = Convert.ToInt32(Encoding.UTF8.GetString(commandResponce));
                        Thread.Sleep(100);
                        if (userId >= 0)
                        {
                            Reciepe reciepe = Reciepes[cbReciepe.SelectedIndex];
                            string text = JsonConvert.SerializeObject(reciepe);

                            //Thread.Sleep(200);
                            //XmlSerializer xmlSerializer = new XmlSerializer(reciepe.GetType());
                            //xmlSerializer.Serialize(stream, reciepe);


                            stream.Write(Encoding.UTF8.GetBytes(text), 0, text.Length);
                            //} while (stream.DataAvailable);
                            Thread.Sleep(1000);
                            stream.Write(Encoding.UTF8.GetBytes(User.Email), 0, User.Email.Length);
                            Thread.Sleep(100);
                            //     stream.Flush();
                          stream.Write(Encoding.UTF8.GetBytes(tbText.Text), 0, tbText.Text.Length);
                        }
                        else
                        {
                            MessageBox.Show("Невірні дані користувача", "", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        #endregion
                        #region SendMessage2
                        //stream.Write(Encoding.UTF8.GetBytes(tbTo.Text), 0, tbTo.Text.Length);
                        //Thread.Sleep(100);
                        //stream.Write(Encoding.UTF8.GetBytes(User.Email), 0, User.Email.Length);
                        //stream.Flush();
                        //Thread.Sleep(100);
                        //stream.Write(Encoding.UTF8.GetBytes(tbText.Text), 0, tbText.Text.Length);
                        //Thread.Sleep(100);

                        //Reciepe reciepe = Reciepes[cbReciepe.SelectedIndex];
                        //XmlSerializer xmlSerializer = new XmlSerializer(reciepe.GetType());
                        //xmlSerializer.Serialize(stream, reciepe);
                        #endregion

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
                MessageBox.Show("Ведіть адресу отримувача та виберіть рецепт", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
