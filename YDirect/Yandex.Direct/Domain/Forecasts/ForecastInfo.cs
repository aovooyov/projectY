namespace Yandex.Direct
{
    /// <summary>
    /// ���������� ��������
    /// </summary>
    public class ForecastInfo
    {
        public ForecastBannerPhraseInfo[] Categories { get; set; }

        public ForecastBannerPhraseInfo[] Phrases { get; set; }

        public ForecastCommonInfo Common { get; set; }
    }
}