using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Input;

namespace YDirect.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        #region WindowPropertys

        public void Error(string message)
        {
            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Warning(string message)
        {
            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void Asterisk(string message)
        {
            MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        public bool Confirm(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public ICommand CloseCommand
        {
            get { return new RelayCommand(Exit); }
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public void DialogResult(bool result)
        {
            Application.Current.MainWindow.DialogResult = result;
        }
        #endregion

        #region Propertychanged

        public void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
    }
}
