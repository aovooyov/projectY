﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yandex.Direct
{
    partial class YandexDirectService
    {
        public int CreateNewReport(NewReportInfo reportInfo)
        {
            if (reportInfo == null)
                throw new ArgumentNullException("reportInfo");

            if (reportInfo.Limit != null && reportInfo.Offset != null)
                throw new ArgumentException("Only one of \"Limit\" and \"Offset\" should be set");

            return YandexApiClient.Invoke<int>(ApiMethod.CreateNewReport, reportInfo);
        }

        public List<ReportInfo> GetReportList()
        {
            return YandexApiClient.Invoke<List<ReportInfo>>(ApiMethod.GetReportList);
        }

        public List<GoalInfo> GetStatGoals(int campaignId)
        {
            return YandexApiClient.Invoke<List<GoalInfo>>(ApiMethod.GetStatGoals, new { CampaignID = campaignId });
        }

        public void DeleteReport(int reportId)
        {
            var result = YandexApiClient.Invoke<int>(ApiMethod.DeleteReport, reportId);

            if (result != 1)
                throw new YandexDirectException("Method DeleteReport failed.");
        }
    }
}
