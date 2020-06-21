using ReciepeBook.Model;
using ReciepeBook.ViewModel.Helper;
using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace ReciepeBook.ViewModel.Commands
{
    public class DeleteCommand : ICommand
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
        public DeleteCommand(ReciepeBookVM vm)
        {
            VM = vm;
        }
        ReciepeBookVM VM { get; set; }
        public bool CanExecute(object parameter)
        {
            if (VM.SelectedReciepe != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            Сulinary_recipeEntities dbReciepe = new Сulinary_recipeEntities();
            DialogResultConverter converter = new DialogResultConverter();
            if (MessageBox.Show("Ви справді хочете видалити цей рецепт?", VM.SelectedReciepe.ReciepeName, MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                ReciepeBookHelper.dbReciepe.Reciepe.Remove(VM.SelectedReciepe);
                ReciepeBookHelper.dbReciepe.SaveChanges();
            }
            VM.GetReciepes();

        }

    }
}
