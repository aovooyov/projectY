using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace YDirect.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TabViewModel> _tabs;
        public ObservableCollection<TabViewModel> Tabs
        {
            get
            {
                if (_tabs == null)
                {
                    _tabs = new ObservableCollection<TabViewModel>();
                    _tabs.CollectionChanged += OnTabsChanged;
                }
                return _tabs;
            }
            set
            {
                _tabs = value;
                OnPropertyChanged(() => Tabs);
            }
        }

        #region Toggle Tab
        public ICommand ToggleInfoTabCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    OnToggleTab<InfoTabViewModel>();
                    OnPropertyChanged(() => IsOpenInfoTab);
                });
            }
        }
        public ICommand ToggleCampaignsCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    OnToggleTab<CampaignsListTabViewModel>();
                    OnPropertyChanged(() => IsOpenCampaignsTab);
                });
            }
        }
        public ICommand ToggleClientsCommand
        {
            get
            {
                return new RelayCommand(() =>
                                            {
                                                OnToggleTab<ClientsListTabViewModel>();
                                                OnPropertyChanged(() => IsOpenClientsTab);
                                            });
            }
        }
        public ICommand ToggleBannersCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    OnToggleTab<BannersListTabViewModel>();
                    OnPropertyChanged(() => IsOpenBannersTab);
                });
            }
        }
        #endregion

        #region Is Open Tab
        public bool IsOpenInfoTab { get { return IsOpenTab<InfoTabViewModel>(); } }
        public bool IsOpenClientsTab { get { return IsOpenTab<ClientsListTabViewModel>(); } }
        public bool IsOpenCampaignsTab { get { return IsOpenTab<CampaignsListTabViewModel>(); } }
        public bool IsOpenBannersTab { get { return IsOpenTab<BannersListTabViewModel>(); } }
        #endregion

        #region private
        private void OnTabsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (TabViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnTabRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (TabViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnTabRequestClose;
        }

        private void OnTabRequestClose(object sender, EventArgs e)
        {
            var tab = sender as TabViewModel;
            if (tab == null)
                return;

            tab.Dispose();
            Tabs.Remove(tab);

            var @switch = new Dictionary<Type, Action>
            {
                {typeof (InfoTabViewModel), () => OnPropertyChanged(() => IsOpenInfoTab)},
                {typeof (ClientsListTabViewModel), () => OnPropertyChanged(() => IsOpenClientsTab)},
                {typeof (CampaignsListTabViewModel), () => OnPropertyChanged(() => IsOpenCampaignsTab)},
                {typeof (BannersListTabViewModel), () => OnPropertyChanged(() => IsOpenBannersTab)}
            };

            if (@switch.ContainsKey(sender.GetType()))
                @switch[sender.GetType()]();
        }

        private void OnToggleTab<T>() where T : class
        {
            var tab = _tabs.FirstOrDefault(t => t is T);
            if (tab != null)
                Tabs.Remove(tab);
            else
            {
                tab = Activator.CreateInstance<T>() as TabViewModel;
                if (tab != null)
                    OpenTab(tab);
            }
        }

        private bool IsOpenTab<T>() where T : class
        {
            return _tabs != null && _tabs.Any(t => t is T);
        }
        #endregion

        public void OpenTab(TabViewModel tab)
        {
            tab.Main = this;
            Tabs.Add(tab);
        }
    }
}
