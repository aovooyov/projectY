using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yandex.Direct
{
    partial class YandexDirectService
    {
        /*
         * Not implemented:
           - CreateOrUpdateCampaign
           - GetBalance
           - GetCampaignParams
           - GetCampaignsListFilter
         */

        public List<ShortCampaignInfo> GetCampaignsList(params string[] logins)
        {
            if (logins == null || logins.Length == 0)
                throw new ArgumentNullException("logins");
            return YandexApiClient.Invoke<List<ShortCampaignInfo>>(ApiMethod.GetCampaignsList, logins);
        }

        public CampaignInfo GetCampaignParams(int campaignId)
        {
            return YandexApiClient.Invoke<CampaignInfo>(ApiMethod.GetCampaignParams, new { CampaignID = campaignId });
        }

        public List<CampaignInfo> GetCampaignsParams(params string[] logins)
        {
            if (logins == null || logins.Length == 0)
                throw new ArgumentNullException("logins");

            return YandexApiClient.Invoke<List<CampaignInfo>>(ApiMethod.GetCampaignsParams, logins);
        }
    }
}
