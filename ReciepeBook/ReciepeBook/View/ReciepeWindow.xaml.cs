using ReciepeBook.Model;
using System.Windows;

namespace ReciepeBook.View
{
    /// <summary>
    /// Interaction logic for ReciepeWindow.xaml
    /// </summary>
    public partial class ReciepeWindow : Window
    {
        ReciepeVM2 VM;
        public ReciepeWindow(Reciepe reciepe)
        {
            InitializeComponent();
            VM = new ReciepeVM2();
            VM.Reciepe = reciepe;
            DataContext = VM;
        }
    }
    public class ReciepeVM2
    {
        public Reciepe Reciepe { get; set; }
    }
}
