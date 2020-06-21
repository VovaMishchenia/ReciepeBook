using Microsoft.Win32;
using ReciepeBook.Model;
using ReciepeBook.ViewModel;
using ReciepeBook.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for AddReciepeWindow.xaml
    /// </summary>
    public partial class AddReciepeWindow : Window
    {
        AddReciepeVM AddReciepeVM { get; set; }
        public AddReciepeWindow(ReciepeBookVM vm)
        {
            InitializeComponent();
            for (int i = 1; i < 11; i++)
            {
                comboBoxRating.Items.Add(i);
            }
            DataContext = AddReciepeVM;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class AddReciepeVM : INotifyPropertyChanged
    {
        public ObservableCollection<Cuisine> Cuisines { get; set; } =
           new ObservableCollection<Cuisine>();
        public ObservableCollection<ReciepeType> ReciepeTypes { get; set; } =
            new ObservableCollection<ReciepeType>();

        private ReciepeType selectedReciepeType;
        private Cuisine  selectedCuisine;
        private string name;
        private string photoPath;
        private int cookingTime;
        private int? raiting;
        private int calories;
        private string components;
        private string reciepeText;


        public string ReciepeText
        {
            get { return reciepeText; }
            set {
                reciepeText = value;
                NotifyPropertyChanged();
            }
        }

        public string Components
        {
            get { return components; }
            set {
                components = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set {
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
        public OPenFileDialogCommand OPenFileDialogCommand { get; set; }
        public AddReciepeCommand AddReciepeCommand { get; set; }
        public AddReciepeVM()
        {
            GetCuisines();
            GetReciepeTypes();
            OPenFileDialogCommand = new OPenFileDialogCommand(this);
            AddReciepeCommand = new AddReciepeCommand(this);
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
        public Cuisine SelectedCuisine
        {
            get { return selectedCuisine; }
            set {
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class OPenFileDialogCommand : ICommand
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
        public OPenFileDialogCommand(AddReciepeVM vm)
        {
            VM = vm;
        }
        AddReciepeVM VM { get; set; }
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

    public class AddReciepeCommand : ICommand
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
        public AddReciepeCommand(AddReciepeVM vm)
        {
            VM = vm;
        }
        AddReciepeVM VM { get; set; }
        public bool CanExecute(object parameter)
        {
            bool can=true;
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
            Сulinary_recipeEntities dbReciepe = new Сulinary_recipeEntities();
            dbReciepe.Reciepe.Add(new Reciepe()
            {
                ReciepeName = VM.Name,
                CuisineId = VM.SelectedCuisine.Id,
                PhotoPath = VM.PhotoPath,
                TypeId = VM.SelectedReciepetype.Id,
                CookingTime=VM.Cookingtime,
                Calories=VM.Calories,
                Rating=VM.Raiting,
                Ingredients=VM.Components,
                Instruction=VM.ReciepeText,
            });
            dbReciepe.SaveChanges();
            MessageBox.Show("Рецепт добавлений", "Новий рецепт", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
