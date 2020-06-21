using ReciepeBook.Model;
using ReciepeBook.View;
using System;
using System.Windows.Input;

namespace ReciepeBook.ViewModel.Commands
{
    public class ListViewItemMouseDoubleClick : ICommand
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
        public ListViewItemMouseDoubleClick(ReciepeBookVM vm)
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
            ReciepeWindow reciepeWindow = new ReciepeWindow(VM.SelectedReciepe);
            reciepeWindow.Show();
        }
    }
}

