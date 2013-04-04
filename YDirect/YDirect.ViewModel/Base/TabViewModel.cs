using System;
using System.Windows.Input;

namespace YDirect.ViewModel
{
    public class TabViewModel : BaseViewModel
    {
        internal MainViewModel Main { get; set; }

        public ICommand CloseCommand
        {
            get { return new RelayCommand(OnRequestClose); }
        }

        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            if (RequestClose != null)
                RequestClose(this, EventArgs.Empty);
        }

        public string Header { get; protected set; }
    }
}
