using System;
using System.Windows.Input;

namespace WpfApp10
{
    internal class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///  コマンド実行時の処理内容を保持します。
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// コマンド実行可能判別の処理内容を保持します。
        /// </summary>
        private Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return (this._canExecute != null) ? this._canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (this._execute != null)
                this._execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var h = this.CanExecuteChanged;
            if (h != null) h(this, EventArgs.Empty);
        }

    }
}