
namespace Yandex.Direct
{
    /*
     *   "Strategy": {
            "StrategyName": (string),
            "MaxPrice": (float),
            "AveragePrice": (float),
            "WeeklySumLimit": (float),
            "ClicksPerWeek": (int)
         },
     * 
     */
    public class CampaignStrategy
    {
        /// <summary>
        /// Стратегия показов на поиске Яндекса.
        /// Стратегии с ручным управлением ставками:
        ///     HighestPosition — стратегия «Наивысшая доступная позиция»;
        ///     LowestCost — стратегия «Показ в блоке по минимальной цене»;
        ///     LowestCostPremium — стратегия «Показ в блоке по минимальной цене» (только в спецразмещении);
        ///     NoPremiumPosition — стратегия "Показ справа от результатов поиска";
        ///     IndependentControl — стратегия "Независимое управление для разных типов площадок".
        /// Стратегии NoPremiumPosition и IndependentControl настраиваются только через веб-интерфейс Яндекс.Директа. Настройка через API не доступна.
        /// Автоматические стратегии:
        ///     WeeklyBudget — автоматическая стратегия «Недельный бюджет»;
        ///     WeeklyPacketOfClicks — автоматическая стратегия «Недельный пакет кликов»;
        ///     AverageClickPrice — автоматическая стратегия «Средняя цена клика».
        /// </summary>
        public string StrategyName { get; set; }

        /// <summary>
        /// Максимальная цена за клик. Может задаваться для стратегий WeeklyBudget и WeeklyPacketOfClicks.
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Средняя цена за клик для стратегии AverageClickPrice. Также может задаваться для стратегии WeeklyPacketOfClicks.
        /// </summary>
        public decimal AveragePrice { get; set; }
        
        /// <summary>
        /// Максимальный бюджет на неделю для стратегии WeeklyBudget. Также может задаваться для стратегии AverageClickPrice.
        /// </summary>
        public decimal WeeklySumLimit { get; set; }

        /// <summary>
        /// Количество кликов в неделю для стратегии WeeklyPacketOfClicks.
        /// </summary>
        public int ClicksPerWeek { get; set; }
    }
}
