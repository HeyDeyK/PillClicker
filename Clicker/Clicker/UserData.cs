using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CsvHelper;
using System.IO;

namespace Clicker
{
    abstract class UserData
    {
        int _MoneyCTR = 0;
        public int MoneyCTR
        {
            get => _MoneyCTR;
            set
            {
                _MoneyCTR = value;
            }
        }

        private int _MoneyClick = 1;
        public int MoneyClick
        {
            get => _MoneyClick;
            set
            {
                _MoneyClick = value;
            }
        }
        private double _MoneyIncome = 0;
        public double MoneyIncome
        {
            get => _MoneyIncome;
            set
            {
                _MoneyIncome = value;
            }
        }
        public int KlikLevel { get; set; } = 1;
        public string UpgKlikLevel { get; set; } = "";

        public int KlikPrice { get; set; } = 200;

        public int DoubleKlikMinutaPrice { get; set; } = 2000;

        public int DoubleKlikMinutaDuration { get; set; } = 0;
        public string DoubleKlikMinutaZbyva { get; set; } = "00:00";

        public int DoubleKlikDesetPrice { get; set; } = 15000;
        public int DoubleKlikDesetDuration { get; set; } = 0;
        public string DoubleKlikDesetDurationZbyva { get; set; } = "00:00";

        public int DoubleKlikPermaPrice { get; set; } = 100000;
        
    }
}
