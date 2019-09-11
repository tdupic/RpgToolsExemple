using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RPGTools.Services
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private object _parameter;

        private Action _action;


        public RelayCommand(Action action)
        {
            this._action = action;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._action();
        }

    }
}
