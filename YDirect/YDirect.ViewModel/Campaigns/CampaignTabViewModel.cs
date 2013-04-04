using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YDirect.Model;
using Yandex.Direct;

namespace YDirect.ViewModel
{
    public class CampaignTabViewModel : TabViewModel
    {
        public CampaignTabViewModel(int campaignId)
        {
            Campaign = Facade.Instance.YandexDirect.GetCampaignParams(campaignId);
            Banners = new ObservableCollection<BannerInfo>(Facade.Instance.YandexDirect.GetBannersForCampaign(campaignId));
            Header = string.Format("Кампания ({0}) \"{1}\"", Campaign.Id, Campaign.Name);
        }

        private CampaignInfo _campaign;
        public CampaignInfo Campaign
        {
            set
            {
                _campaign = value;
                OnPropertyChanged(() => Campaign);
            }
            get { return _campaign; }
        }

        private ObservableCollection<BannerInfo> _banners;
        private bool _autoChecked;

        public ObservableCollection<BannerInfo> Banners
        {
            set
            {
                _banners = value;
                OnPropertyChanged(() => Banners);
            }
            get
            {
                return _banners;
            }
        }

        public bool AutoChecked
        {
            get
            {
                return _autoChecked;
            }
            set
            {
                _autoChecked = value;
                if(_autoChecked) Error("errror");
                Campaign.Strategy.MaxPrice = 50;


                OnPropertyChanged(() => AutoChecked);
            }
        }

        //public ICommand BannersListCommand { get { return new RelayCommand(BannersList); } }

        //private void BannersList()
        //{
        //    if(Main == null || Campaign == null)
        //        return;
            
        //    try
        //    {
        //        var bannersTab = new BannersListTabViewModel(Campaign.Id);
        //        Main.OpenTab(bannersTab);
        //    }
        //    catch (Exception e)
        //    {
        //        Error(e.Message);
        //    }
        //}
    }
}
