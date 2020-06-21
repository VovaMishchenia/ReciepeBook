using Microsoft.Win32;
using ReciepeBook.Model;
using ReciepeBook.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ChangeReciepeWindow.xaml
    /// </summary>
    public partial class ChangeReciepeWindow : Window
    {
        ChangeReciepeVM VM { get; set; }
        public ChangeReciepeWindow(Reciepe selectedReciepe)
        {
            InitializeComponent();
            VM = new ChangeReciepeVM();
            VM.Name=selectedReciepe.ReciepeName;
            VM.SelectedReciepetype=selectedReciepe.ReciepeType;
            VM.PhotoPath=selectedReciepe.PhotoPath;
            VM.SelectedCuisine=selectedReciepe.Cuisine;
            VM.Cookingtime=selectedReciepe.CookingTime;
            VM.Raiting=selectedReciepe.Rating;
            VM.Calories=selectedReciepe.Calories;
            VM.Components=selectedReciepe.Ingredients;
            VM.ReciepeText=selectedReciepe.Instruction;
            VM.Id=selectedReciepe.Id;
            DataContext = VM;
            for (int i = 1; i < 11; i++)
            {
                comboBoxRating.Items.Add(i);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
    public class ChangeReciepeVM: INotifyPropertyChanged
    {
        public ObservableCollection<Cuisine> Cuisines { get; set; } =
           new ObservableCollection<Cuisine>();
        public ObservableCollection<ReciepeType> ReciepeTypes { get; set; } =
            new ObservableCollection<ReciepeType>();
        public OpenPhotoDialog OpenPhotoDialog { get; set; }
        public ChangeCommand ChangeCommand { get; set; }
        public ChangeReciepeVM()
        {
            GetCuisines();
            GetReciepeTypes();
            OpenPhotoDialog = new OpenPhotoDialog(this);
            ChangeCommand = new ChangeCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetReciepeTypes()
        {
            var rec = ReciepeBookHelper.GetReciepeTypes();
            ReciepeTypes.Clear();
            foreach (var item in rec)
            {
                ReciepeTypes.Add(item);
            }
        }
        public void GetCuisines()
        {
            var rec = ReciepeBookHelper.GetCuisines();
            Cuisines.Clear();
            foreach (var item in rec)
            {
                Cuisines.Add(item);
            }
        }
        
        private ReciepeType selectedReciepeType;
        private Cuisine selectedCuisine;
        private string name;
        private string photoPath;
        private int cookingTime;
        private int? raiting;
        private int calories;
        private string components;
        private string reciepeText;
        public int Id;

        public string ReciepeText
        {
            get { return reciepeText; }
            set
            {
                reciepeText = value;
                NotifyPropertyChanged();
            }
        }

        public string Components
        {
            get { return components; }
            set
            {
                components = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        public string PhotoPath
        {
            get { return photoPath; }
            set
            {
                photoPath = value;
                NotifyPropertyChanged();
            }
        }
        public int Cookingtime
        {
            get { return cookingTime; }
            set
            {
                cookingTime = value;
                NotifyPropertyChanged();
            }
        }
        public int? Raiting
        {
            get { return raiting; }
            set
            {
                raiting = value;
                NotifyPropertyChanged();
            }
        }
        public int Calories
        {
            get { return calories; }
            set
            {
                calories = value;
                NotifyPropertyChanged();
            }
        }
        public Cuisine SelectedCuisine
        {
            get { return selectedCuisine; }
            set
            {
                selectedCuisine = value;
                NotifyPropertyChanged();
            }
        }
        public ReciepeType SelectedReciepetype
        {
            get { return selectedReciepeType; }
            set
            {
                selectedReciepeType = value;
                NotifyPropertyChanged();
            }
        }
    }

    public class OpenPhotoDialog : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public OpenPhotoDialog(ChangeReciepeVM vm)
        {
            VM = vm;
        }
        ChangeReciepeVM VM { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG|*.jpg|PNG|*.png";
            if (openFile.ShowDialog() == true)
            {
                VM.PhotoPath = openFile.FileName;

            }
        }
    }

    public class ChangeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public ChangeCommand(ChangeReciepeVM vm)
        {
            VM = vm;
        }
        ChangeReciepeVM VM { get; set; }
        public bool CanExecute(object parameter)
        {
            bool can = true;
            if (!String.IsNullOrEmpty(VM.Name) && VM.SelectedCuisine != null && !String.IsNullOrEmpty(VM.PhotoPath)
                && VM.SelectedReciepetype != null && VM.Cookingtime > 0 && VM.Calories > 0 && VM.Raiting != null
                && !String.IsNullOrEmpty(VM.Components) && !String.IsNullOrEmpty(VM.ReciepeText))
                can = true;
            else
                can = false;

            return can;
        }

        public void Execute(object parameter)
        {
            var item = ReciepeBookHelper.dbReciepe.Reciepe.Find(VM.Id);
            item.ReciepeName = VM.Name;
            item.CuisineId = VM.SelectedCuisine.Id;
            item.PhotoPath = VM.PhotoPath;
            item.TypeId = VM.SelectedReciepetype.Id;
            item.CookingTime = VM.Cookingtime;
            item.Calories = VM.Calories;
            item.Rating = VM.Raiting;
            item.Ingredients = VM.Components;
            item.Instruction = VM.ReciepeText;
            ReciepeBookHelper.dbReciepe.SaveChanges();
            MessageBox.Show("Дані були зміненні успішно", "Дані змінені", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
