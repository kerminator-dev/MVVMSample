using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMSample
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute; 

        public event EventHandler? CanExecuteChanged
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

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.execute = executeAction;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> executeAction) : this (executeAction, null)
        {
            
        }

        public bool CanExecute(object? parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
