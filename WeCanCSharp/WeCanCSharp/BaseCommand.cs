using System;
using System.Windows.Input;

namespace WeCanCSharp
{
    public abstract class BaseCommand : ICommand
    {
#pragma warning disable 67

        public event EventHandler CanExecuteChanged;

#pragma warning restore 67

        public bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
    }
}