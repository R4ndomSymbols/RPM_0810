using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RPM_0810
{
    public class BasicVM
    {
        public ICommand BasicCommand
        {
            get => new DelCommand((o) => MessageBox.Show("Действие произошло"), (o) => true);
        }
    }

    public class DelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object> action;
        private Func<object, bool> possible;

        public DelCommand(Action<object> exec, Func<object, bool> canexec)
        {
            possible = canexec;
            action = exec;

        }


        public bool CanExecute(object? parameter)
        {
            return possible(parameter);
        }

        public void Execute(object? parameter)
        {
            action.Invoke(parameter);
        }
    }


}
