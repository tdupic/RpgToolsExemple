using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppAdmin.Services
{
    public class RelayCommand : ICommand
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
