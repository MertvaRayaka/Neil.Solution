using System;
using System.Windows.Input;

namespace Neil.MyWPF.Commands
{
    class ButtonCommand : ICommand
    {
        private Action WhattoExecute;
        private Func<bool> WhentoExecute;

        public ButtonCommand(Action what,Func<bool> when)//构造函数注入
        {
            WhattoExecute = what;
            WhentoExecute = when;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => WhentoExecute();

        public void Execute(object parameter)
        {
            WhattoExecute();
        }
    }
}
