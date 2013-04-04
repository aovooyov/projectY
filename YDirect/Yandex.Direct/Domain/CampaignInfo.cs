using Newtonsoft.Json;
using Yandex.Direct.Serialization;

namespace Yandex.Direct
{
    public class CampaignInfo : ShortCampaignInfo
    {
        /// <summary>
        /// Объект CampaignStrategy, описывающий стратегию показов.
        /// </summary>
        public CampaignStrategy Strategy { get; set; }
        /// <summary>
        /// При показе учитывать предпочтения пользователей (поведенческий таргетинг) — Yes/No.
        /// </summary>
        [JsonConverter(typeof(YesNoConverter))]
        public bool StatusBehavior { get; set; }

        /// <summary>
        /// При отключении фраз за низкий CTR также останавливать показы на сайтах рекламной сети Яндекса — Yes/No.
        /// </summary>
        [JsonConverter(typeof(YesNoConverter))]
        public bool StatusContextStop { get; set; }

        /// <summary>
        /// Максимальная цена за клик в рекламной сети Яндекса на тематических площадках. Указывается в процентах от цены за клик на поиске Яндексе. 
        /// Значение кратно десяти: 10, 20... 100.
        /// </summary>
        public int ContextPricePercent { get; set; }

        /// <summary>
        /// Ограничение бюджета при показе объявлений в рекламной сети Яндекса на тематических площадках:
        /// Default — бюджет не ограничен;
        /// Limited — бюджет ограничен значением параметра ContextLimitSum.
        /// </summary>
        public string ContextLimit { get; set; }

        /// <summary>
        /// Максимальный процент бюджета, расходуемый для показа объявлений в рекламной сети Яндекса на тематических площадках. 
        /// Значение кратно десяти или равняется нулю: 0, 10, 20... 100.
        /// </summary>
        public int ContextLimitSum { get; set; }

        /// <summary>
        /// Список сайтов рекламной сети Яндекса, на которых не показываются объявления кампании.
        /// </summary>
        public string DisabledDomains { get; set; }

        /// <summary>
        /// Включен автофокус — Yes/No.
        /// </summary>
        [JsonConverter(typeof(YesNoConverter))]
        public bool AutoOptimization { get; set; }

        /// <summary>
        /// Останавливать показы при недоступности сайта рекламодателя — Yes/No.
        /// Недоступность сайта выявляется по результатам мониторинга, который проводится сервисом Яндекс.Метрика.
        /// </summary>
        [JsonConverter(typeof(YesNoConverter))]
        public bool StatusMetricaControl { get; set; }

        /// <summary>
        /// Список IP-адресов, которым не показываются объявления кампании.
        /// </summary>
        public string DisabledIps { get; set; }

        /// <summary>
        /// При переходе по объявлению на сайт рекламодателя приписывать к URL метку в формате OpenStat — Yes/No.
        /// </summary>
        [JsonConverter(typeof(YesNoConverter))]
        public bool StatusOpenStat { get; set; }

        /// <summary>
        /// При расчете цены за клик учитывать только те конкурирующие объявления, 
        /// которые показываются на момент расчета (не остановлены временным таргетингом), — Yes/No.
        /// </summary>
        [JsonConverter(typeof(YesNoConverter))]
        public bool ConsiderTimeTarget { get; set; }
    }

    /*    CampaignInfo 
         base "Login" string),
         base "CampaignID" int),
         base "Name" string),
         base "FIO" string),
         base "StartDate" date),
         base "Sum" float),
         base "Rest" float),
         base "Shows" int),
         base "Clicks" int),
         "Strategy": {
             CampaignStrategy 
            "StrategyName" string),
            "MaxPrice" float),
            "AveragePrice" float),
            "WeeklySumLimit" float),
            "ClicksPerWeek" int)
         },
         "SmsNotification": {
             SmsNotificationInfo 
            "MetricaSms" string),
            "ModerateResultSms" string),
            "MoneyInSms" string),
            "MoneyOutSms" string),
            "SmsTimeFrom" string),
            "SmsTimeTo" string)
         },
         "EmailNotification": {
             EmailNotificationInfo 
            "Email" string),
            "SendWarn" string),
            "WarnPlaceInterval" int),
            "MoneyWarningValue" int),
            "SendAccNews" string)
         },
         "StatusBehavior" string),
         base "Status" string),
         "TimeTarget": {
             TimeTargetInfo 
            "ShowOnHolidays" string),
            "HolidayShowFrom" int),
            "HolidayShowTo" int),
            "DaysHours": [
               {   TimeTargetItem 
                  "Hours": [
                     (int)
                     ...
                  ],
                  "Days": [
                     (int)
                     ...
                  ]
               }
               ...
            ],
            "TimeZone" string)
         },
         "StatusContextStop" string),
         "ContextLimit" string),
         "ContextLimitSum" int),
         "ContextPricePercent" int),
         "AutoOptimization" string),
         "StatusMetricaControl" string),
         "DisabledDomains" string),
         "DisabledIps" string),
         "StatusOpenStat" string),
         "ConsiderTimeTarget" string),
         base "ManagerName" string),
         base "AgencyName" string),
         base "StatusShow" string),
         base "StatusArchive" string),
         base "StatusActivating" string),
         base "StatusModerate" string),
         base "IsActive" string),
         "MinusKeywords": [
            (string)
            ...
         ],
         "AddRelevantPhrases" string),
         "RelevantPhrasesBudgetLimit" int),
         "SumAvailableForTransfer" float)
      }
*/
}
