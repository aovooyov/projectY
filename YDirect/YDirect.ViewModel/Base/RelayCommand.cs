using System;
using System.Windows.Input;

namespace YDirect.ViewModel
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _command;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action command, Func<object, bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            _canExecute = canExecute;
            _command = command;
        }

        public void Execute(object parameter)
        {
            _command();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
