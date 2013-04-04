using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YDirect.Model;
using Yandex.Direct;

namespace YDirect.ViewModel
{
    public class BannersListTabViewModel : TabViewModel
    {
        public BannersListTabViewModel(int campaignId)
        {
            Banners = new ObservableCollection<BannerInfo>(
                Facade.Instance.YandexDirect.GetBannersForCampaign(campaignId));

            Header = "[Banners]";
        }

        private ObservableCollection<BannerInfo> _banners;
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
    }
}
