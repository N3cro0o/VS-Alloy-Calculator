using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alloy_Calc.Core
{
    internal class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        private string? _name;
        public string? Name
        {
            get
            {
                return !string.IsNullOrEmpty(_name) ? _name : "default";
            }
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute, string? name = "")
        {
            _execute = execute;
            _canExecute = canExecute;
            _name = name;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
