using ReciepeBook.Model;
using ReciepeBook.View;
using ReciepeBook.ViewModel.Commands;
using ReciepeBook.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReciepeBook.ViewModel
{
    public class ReciepeBookVM : INotifyPropertyChanged
    {
        private Reciepe selectedReciepe;
        private ReciepeType selectedReciepeType;
        public ObservableCollection<Reciepe> Reciepes { get; set; } =
            new ObservableCollection<Reciepe>();
        public ObservableCollection<Cuisine> Cuisines { get; set; } =
            new ObservableCollection<Cuisine>();
        public ObservableCollection<ReciepeType> ReciepeTypes { get; set; } =
            new ObservableCollection<ReciepeType>();
        public MouseDownCommand MouseDownCommand { get; set; }

        public ListViewItemMouseDoubleClick ListViewItemMouseDoubleClick { get; set; }
        public ShowByCategoryCommand ShowByCategoryCommand { get; set; }
        public OpenAddReciepeCommand OpenAddReciepeCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public ShowAllCommand ShowAllCommand { get; set; }
        public OpenChangeWindowCommand OpenChangeWindowCommand { get; set; }
        private Cuisine selectedCuisine;
        private int? rating;
        private int? calories;
        private int? cookingTime;
        public Cuisine SelectedCuisine {
            get { return selectedCuisine; }
            set
            {
                selectedCuisine = value;
                NotifyPropertyChanged();
            }
        }
        public int? Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                NotifyPropertyChanged();
            }
        }
        public int? Calories
        {
            get { return calories; }
            set
            {
                calories = value;
                NotifyPropertyChanged();
            }
        }
        public int? CookingTime
        {
            get { return cookingTime; }
            set
            {
                cookingTime = value;
                NotifyPropertyChanged();
            }
        }

        public ReciepeBookVM()
        {
            GetCuisines();
            GetReciepes();
            GetReciepeTypes();
            MouseDownCommand = new MouseDownCommand(this);
            ShowByCategoryCommand = new ShowByCategoryCommand(this);
            ListViewItemMouseDoubleClick = new ListViewItemMouseDoubleClick(this);
            ShowAllCommand = new ShowAllCommand(this);
            OpenAddReciepeCommand = new OpenAddReciepeCommand(this);
            DeleteCommand = new DeleteCommand(this);
            OpenChangeWindowCommand = new OpenChangeWindowCommand(this);
        }
        public Reciepe SelectedReciepe
        {
            get { return selectedReciepe; }
            set
            {
                selectedReciepe = value;
                NotifyPropertyChanged();
            }
        }
        public ReciepeType SelectedReciepeType
        {
            get { return selectedReciepeType; }
            set
            {
                selectedReciepeType = value;
                NotifyPropertyChanged();
            }
        }
        public void GetReciepes()
        {
            var rec = ReciepeBookHelper.GetReciepes();
            Reciepes.Clear();
            foreach (var item in rec)
            {
                Reciepes.Add(item);
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
        public void GetReciepeTypes()
        {
            var rec = ReciepeBookHelper.GetReciepeTypes();
            ReciepeTypes.Clear();
            foreach (var item in rec)
            {
                ReciepeTypes.Add(item);
            }
        }
        public void GetReciepesByType()
        {
            var rec = ReciepeBookHelper.GetReciepesByType(selectedReciepeType);
            Reciepes.Clear();
            foreach (var item in rec)
            {
                Reciepes.Add(item);
            }
        }
        public void GetReciepesByCategories()
        {
            var rec = ReciepeBookHelper.GetReciepesByCategory(selectedCuisine,Rating,Calories,CookingTime);
            Reciepes.Clear();
            foreach (var item in rec)
            {
                Reciepes.Add(item);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
