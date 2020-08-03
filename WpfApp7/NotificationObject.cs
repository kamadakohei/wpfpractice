using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp7
{
    internal abstract class NotificationObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged の実装

        /// <summary>
        /// プロパティに変更があった場合に発生します
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }



        /// <summary>
        /// プロパティを変更するヘルパーです
        /// </summary>
        /// <typeparam name="T">プロパティの型を表します</typeparam>
        /// <param name="target">変更するプロパティの実体をrefで指定します</param>
        /// <param name="value">変更後の値を指定します</param>
        /// <param name="propertyName">プロパティ名を指定します</param>
        /// <returns>プロパティ値に変更があった場合にTrueを返します</returns>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(target, value))
                return false;
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        #endregion INotifyPropertyChangedの実装
    }
}