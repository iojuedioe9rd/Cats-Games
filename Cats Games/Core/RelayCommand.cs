using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cats_Games.Core
{
    class RelayCommand : ICommand
    {
        private Action<object?> exe;
        private Func<object?, bool>? canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> exe, Func<object?, bool>? canExecute = null)
        {
            this.exe = exe;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? par)
        {
            return canExecute == null || canExecute(par);
        }

        public void Execute(object? par)
        {
            exe(par);
        }

    }
}
