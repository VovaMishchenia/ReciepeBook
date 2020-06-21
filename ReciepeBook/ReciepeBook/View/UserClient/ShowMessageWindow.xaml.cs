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

namespace ReciepeBook.View.UserClient
{
    /// <summary>
    /// Interaction logic for ShowMessageWindow.xaml
    /// </summary>
    public partial class ShowMessageWindow : Window
    {
        public Reciepe Reciepe { get; set; }
        public string Text { get; set; }
        public ShowMessageWindow(Message message)
        {
            InitializeComponent();
            Reciepe = message.Reciepe;
            Text = message.Text;
            DataContext = this;
        }
    }
}
