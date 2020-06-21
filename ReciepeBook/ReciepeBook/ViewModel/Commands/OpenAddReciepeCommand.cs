using ReciepeBook.View;
using System;
using System.Windows.Input;

namespace ReciepeBook.ViewModel.Commands
{
    public class OpenAddReciepeCommand : ICommand
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
        public OpenAddReciepeCommand(ReciepeBookVM vm)
        {
            VM = vm;
        }
        ReciepeBookVM VM { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddReciepeWindow addReciepeWindow = new AddReciepeWindow(VM);
            addReciepeWindow.Show();
        }

    }

}
