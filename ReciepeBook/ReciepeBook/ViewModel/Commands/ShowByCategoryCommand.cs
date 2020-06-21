using System;
using System.Windows.Input;

namespace ReciepeBook.ViewModel.Commands
{
    public class ShowByCategoryCommand : ICommand
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
        public ShowByCategoryCommand(ReciepeBookVM vm)
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
            VM.GetReciepesByCategories();
        }
    }
}
