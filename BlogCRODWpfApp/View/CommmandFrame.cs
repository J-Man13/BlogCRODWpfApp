using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlogCRODWpfApp.View
{
    public class CommmandFrame : ICommand
    {
        private Action<Object> _action;
        private bool _canExecute;

        public event EventHandler CanExecuteChanged;

        public CommmandFrame(Action<Object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

    }
}
