using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clicker.Database
{
    class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int MoneyCTR;
        public int MoneyClick;
        public double MoneyIncome;
        public int KlikLevel;
        public int KlikPrice;
        public int DoubleKlikMinutaPrice;
        public int DoubleKlikMinutaDuration;
        public int DoubleKlikDesetPrice;
        public int DoubleKlikDesetDuration;
    }
}
