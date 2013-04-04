using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YDirect.Model;
using Yandex.Direct;

namespace YDirect.ViewModel
{
    public class CampaignsListTabViewModel : TabViewModel
    {
        public CampaignsListTabViewModel()
        {
            Header = "Компании";
        }

        private ObservableCollection<ShortCampaignInfo> _campaigns;
        private ShortCampaignInfo _campaign;

        public ObservableCollection<ShortCampaignInfo> Campaigns
        {
            set
            {
                _campaigns = value;
                OnPropertyChanged(() => Campaigns);
            }
            get
            {
                return _campaigns ??
                       (_campaigns =
                        new ObservableCollection<ShortCampaignInfo>(
                            Facade.Instance.YandexDirect.GetCampaignsList(Facade.Instance.Logins)));
            }
        }

        //public ShortCampaignInfo SelectedCampaign
        //{
        //    get { return _campaign; }
        //    set
        //    {
        //        _campaign = value;
        //        OnPropertyChanged(() => SelectedCampaign);
        //    }
        //}

        public void OpenSelectedCampaignTab(object selectedCampaign)
        {
            if (Main == null || selectedCampaign == null)
                return;

            var shortCampaignInfo = selectedCampaign as ShortCampaignInfo;
            if (shortCampaignInfo == null)
                return;

            try
            {
                var campaignTab = new CampaignTabViewModel(shortCampaignInfo.Id);
                Main.OpenTab(campaignTab);
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
        }
    }
}
