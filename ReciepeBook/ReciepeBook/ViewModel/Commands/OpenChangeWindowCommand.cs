using ReciepeBook.View;
using System;
using System.Windows.Input;

namespace ReciepeBook.ViewModel.Commands
{
    public class OpenChangeWindowCommand : ICommand
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
        public OpenChangeWindowCommand(ReciepeBookVM vm)
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
            ChangeReciepeWindow window = new ChangeReciepeWindow(VM.SelectedReciepe);
            window.Show();
        }


    }
}
