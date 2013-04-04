using System.Collections.ObjectModel;
using YDirect.Model;
using Yandex.Direct;

namespace YDirect.ViewModel
{
    public class ClientsListTabViewModel : TabViewModel
    {
        public ClientsListTabViewModel()
        {
            Header = "Клиенты";
        }

        private ObservableCollection<ShortClientInfo> _clients;
        public ObservableCollection<ShortClientInfo> Clients
        {
            set
            {
                _clients = value;
                OnPropertyChanged(() => Clients);
            }
            get
            {
                return _clients ?? (_clients = new ObservableCollection<ShortClientInfo>(Facade.Instance.ClientList));
            }
        }
    }
}
