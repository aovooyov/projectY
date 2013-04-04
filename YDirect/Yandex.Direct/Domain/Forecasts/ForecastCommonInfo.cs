namespace Yandex.Direct
{
    public class ForecastCommonInfo
    {
        /// <summary>�������������� ��������, ������������� ����� �������</summary>
        public string Geo { get; set; }

        /// <summary>�������������� ��������� ���������� ������� ����������</summary>
        public int Shows { get; set; }

        /// <summary>�������������� ��������� ���������� ������ �� �����������</summary>
        public int Clicks { get; set; }

        /// <summary>�������������� ��������� ���������� ������ �� ����������� �� ������ �����</summary>
        public int FirstPlaceClicks { get; set; }

        /// <summary>�������������� ��������� ���������� ������ �� ����������� � ��������������</summary>
        public int PremiumClicks { get; set; }

        /// <summary>����������� ������ ��� ��������������� ���������� ������� (����� ������� �� ������ ����� � � ��������������)</summary>
        public decimal Min { get; set; }

        /// <summary>����������� ������ ��� ��������������� ���������� ������� �� ������ �����</summary>
        public decimal Max { get; set; }

        /// <summary>����������� ������ ��� ��������������� ���������� ������� � ��������������</summary>
        public decimal PremiumMin { get; set; }
    }
}