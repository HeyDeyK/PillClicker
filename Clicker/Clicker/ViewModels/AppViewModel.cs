using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clicker
{
    class AppViewModel : UserData, INotifyPropertyChanged
    {
        

        private int _TovarnaPrice = 50;
        public int TovarnaPrice
        {
            get => _TovarnaPrice;
            set
            {
                _TovarnaPrice = value;
            }
        }
        private int _TovarnaCount = 1   ;
        public int TovarnaCount
        {
            get => _TovarnaCount;
            set
            {
                _TovarnaCount = value;
            }
        }
        private int _ProdejnaPrice = 1000;
        public int ProdejnaPrice
        {
            get => _ProdejnaPrice;
            set
            {
                _ProdejnaPrice = value;
            }
        }
        private int _ProdejnaCount = 1;
        public int ProdejnaCount
        {
            get => _ProdejnaCount;
            set
            {
                _ProdejnaCount = value;
            }
        }
        private int _LabPrice = 15000;
        public int LabPrice
        {
            get => _LabPrice;
            set
            {
                _LabPrice = value;
            }
        }
        private int _LabCount = 1;
        public int LabCount
        {
            get => _LabCount;
            set
            {
                _LabCount = value;
            }
        }
        private int _KanclPrice = 50000;
        public int KanclPrice
        {
            get => _KanclPrice;
            set
            {
                _KanclPrice = value;
            }
        }
        private int _KanclCount = 1;
        public int KanclCount
        {
            get => _KanclCount;
            set
            {
                _KanclCount = value;
            }
        }

        private double _TovarnaIncome = 0;
        public double TovarnaIncome
        {
            get => _TovarnaIncome;
            set
            {
                _TovarnaIncome = value;
            }
        }
        private double _ProdejnaIncome = 0;
        public double ProdejnaIncome
        {
            get => _ProdejnaIncome;
            set
            {
                _ProdejnaIncome = value;
            }
        }
        private double _LabIncome = 0;
        public double LabIncome
        {
            get => _LabIncome;
            set
            {
                _LabIncome = value;
            }
        }
        private double _KanclIncome = 0;
        public double KanclIncome
        {
            get => _KanclIncome;
            set
            {
                _KanclIncome = value;
            }
        }
        private double _SliderPomerValue = 0;
        public double SliderPomerValue
        {
            get => _SliderPomerValue;
            set
            {
                double StepValue = 10;
                var newStep = Math.Round(value / StepValue);

                _SliderPomerValue = newStep * StepValue;
                Console.WriteLine(SliderPomerValue);
            }
        }
        public string TovarnaColor { get; set; } = "red";
        public string ProdejnaColor { get; set; } = "red";
        public string LabColor { get; set; } = "red";
        public string KanclColor { get; set; } = "red";

        public string TovarnaImage { get; set; } = "pillback2.jpeg";
        public string ProdejnaImage { get; set; } = "pillback3.jpeg";
        public string LabImage { get; set; } = "pillback1.jpeg";
        public string KanclImage { get; set; } = "pillback4.jpeg";

        ICommand tovarnaUpgrade;
        ICommand prodejnaUpgrade;
        ICommand labUpgrade;
        ICommand kanclUpgrade;
        ICommand tapAddMoney;
        public ICommand TapAddMoney
        {
            get { return tapAddMoney; }
        }
        public ICommand TovarnaUpgrade
        {
            get { return tovarnaUpgrade; }
        }
        public ICommand ProdejnaUpgrade
        {
            get { return prodejnaUpgrade; }
        }
        public ICommand LabUpgrade
        {
            get { return labUpgrade; }
        }
        public ICommand KanclUpgrade
        {
            get { return kanclUpgrade; }
        }


        public AppViewModel()
        {
            AddCommands();
            TimedFunction(100);
            TimedFunctionShort(250);
            Ulozit();
        }
        public void Ulozit()
        {
            /*
            TextWriter fileReader = new StreamWriter(@"textwriter.csv");
            var csv = new CsvWriter(fileReader);
            var record = new SavedData { MoneyCTR = MoneyCTR, MoneyClick = MoneyClick, KlikLevel = KlikLevel, KlikPrice = KlikPrice, MoneyIncome = MoneyIncome, DoubleKlikDesetDuration = DoubleKlikDesetDuration, DoubleKlikDesetPrice = DoubleKlikDesetPrice, DoubleKlikMinutaDuration = DoubleKlikMinutaDuration, DoubleKlikMinutaPrice = DoubleKlikMinutaPrice };
            csv.WriteRecord(record);
            */
        }
        private void AddCommands()
        {
            tovarnaUpgrade = new Command(AutoFactory);
            prodejnaUpgrade = new Command(AutoProdejna);
            labUpgrade = new Command(AutoLab);
            kanclUpgrade = new Command(AutoKancl);
            tapAddMoney = new Command(AddMoneyF);
        }
        void OnSliderValueChanged()
        {
            double StepValue = 10;
            var newStep = Math.Round(SliderPomerValue / StepValue);

            SliderPomerValue = newStep * StepValue;
            Console.WriteLine(SliderPomerValue);
        }
        private void AddMoneyF()
        {
            Console.WriteLine(MoneyClick);
            MoneyCTR = MoneyCTR+ MoneyClick;
            OnPropertyChanged("MoneyCTR");
        }
        public void TimedFunction(int cas)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = cas;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }
        public void TimedFunctionShort(int cas)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = cas;
            timer.Elapsed += OnTimedEventShort;
            timer.Enabled = true;
        }
        private void OnTimedEventShort(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckButtonsPrices();
        }
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            double Income = MoneyIncome / 10;
            MoneyCTR = MoneyCTR + (int)Income;
            OnPropertyChanged("MoneyCTR");

        }
        private void CheckButtonsPrices()
        {
            if(TovarnaPrice<= MoneyCTR)
            {
                TovarnaColor = "Green";
                OnPropertyChanged("TovarnaColor");
            }
            else
            {
                TovarnaColor = "Red";
                OnPropertyChanged("TovarnaColor");
            }
            if (ProdejnaPrice <= MoneyCTR)
            {
                ProdejnaColor = "Green";
                OnPropertyChanged("ProdejnaColor");
            }
            else
            {
                ProdejnaColor = "Red";
                OnPropertyChanged("ProdejnaColor");
            }
            if (LabPrice <= MoneyCTR)
            {
                LabColor = "Green";
                OnPropertyChanged("LabColor");
            }
            else
            {
                LabColor = "Red";
                OnPropertyChanged("LabColor");
            }
            if (KanclPrice <= MoneyCTR)
            {
                KanclColor = "Green";
                OnPropertyChanged("KanclColor");
            }
            else
            {
                KanclColor = "Red";
                OnPropertyChanged("KanclColor");
            }

        }
        
        void AutoFactory()
        {
            if(MoneyCTR>=TovarnaPrice)
            {
                TovarnaCount++;
                MoneyCTR = MoneyCTR - TovarnaPrice;
                TovarnaIncome = TovarnaCount * 5;
                
                double NewPrice = TovarnaPrice * Math.Pow(1.1,TovarnaCount);
                TovarnaPrice = Convert.ToInt32(NewPrice);

                MoneyIncome = TovarnaIncome + ProdejnaIncome + LabIncome + KanclIncome;
                OnPropertyChanged("TovarnaPrice");
                OnPropertyChanged("MoneyCTR");
                OnPropertyChanged("MoneyIncome");
                if (TovarnaCount == 2)
                {
                    TovarnaImage = "pillback2_lvl1.jpg";
                    OnPropertyChanged("TovarnaImage");
                }
                else if(TovarnaCount == 5)
                {
                    TovarnaImage = "pillback2_lvl2.jpg";
                    OnPropertyChanged("TovarnaImage");
                }
                else if (TovarnaCount == 10)
                {
                    TovarnaImage = "pillback2_lvl3.jpg";
                    OnPropertyChanged("TovarnaImage");
                }
            }
            
        }

        void AutoProdejna()
        {
            if (MoneyCTR >= ProdejnaPrice)
            {
                ProdejnaCount++;
                MoneyCTR = MoneyCTR - ProdejnaPrice;
                ProdejnaIncome = ProdejnaCount * 20;

                double NewPrice = 1000 * Math.Pow(1.5, ProdejnaCount);
                Console.WriteLine(NewPrice);
                ProdejnaPrice = Convert.ToInt32(NewPrice);

                MoneyIncome = TovarnaIncome + ProdejnaIncome + LabIncome + KanclIncome;
                OnPropertyChanged("ProdejnaPrice");
                OnPropertyChanged("MoneyCTR");
                OnPropertyChanged("MoneyIncome");
                
                if (ProdejnaCount == 2)
                {
                    ProdejnaImage = "pillback3_lvl1.jpg";
                    OnPropertyChanged("ProdejnaImage");
                }
                else if (ProdejnaCount == 5)
                {
                    ProdejnaImage = "pillback3_lvl2.jpg";
                    OnPropertyChanged("ProdejnaImage");
                }
                else if (ProdejnaCount == 10)
                {
                    ProdejnaImage = "pillback3_lvl3.jpg";
                    OnPropertyChanged("ProdejnaImage");
                }
            }

        }


        void AutoLab()
        {
            if (MoneyCTR >= LabPrice)
            {
                LabCount++;
                MoneyCTR = MoneyCTR - LabPrice;
                LabIncome = LabCount * 50;

                double NewPrice = 15000 * Math.Pow(1.5, LabCount);
                Console.WriteLine(NewPrice);
                LabPrice = Convert.ToInt32(NewPrice);

                MoneyIncome = TovarnaIncome + ProdejnaIncome + LabIncome + KanclIncome;
                OnPropertyChanged("LabPrice");
                OnPropertyChanged("MoneyCTR");
                OnPropertyChanged("MoneyIncome");
                
                if (LabCount == 2)
                {
                    LabImage = "pillback1_lvl1.jpg";
                    OnPropertyChanged("LabImage");
                }
                else if (LabCount == 5)
                {
                    LabImage = "pillback1_lvl2.jpg";
                    OnPropertyChanged("LabImage");
                }
                else if (LabCount == 10)
                {
                    LabImage = "pillback1_lvl3.jpg";
                    OnPropertyChanged("LabImage");
                }
            }

        }
        void AutoKancl()
        {
            if (MoneyCTR >= KanclPrice)
            {
                KanclCount++;
                MoneyCTR = MoneyCTR - KanclPrice;
                KanclIncome = KanclIncome * 100;

                double NewPrice = 50000 * Math.Pow(1.5, KanclCount);
                Console.WriteLine(NewPrice);
                KanclPrice = Convert.ToInt32(NewPrice);

                MoneyIncome = TovarnaIncome + ProdejnaIncome + LabIncome + KanclIncome;
                OnPropertyChanged("KanclPrice");
                OnPropertyChanged("MoneyCTR");
                OnPropertyChanged("MoneyIncome");
                
                if (KanclCount == 2)
                {
                    KanclImage = "pillback4_lvl1.jpg";
                    OnPropertyChanged("KanclImage");
                }
                else if (KanclCount == 5)
                {
                    KanclImage = "pillback4_lvl2.jpg";
                    OnPropertyChanged("KanclImage");
                }
                else if (KanclCount == 10)
                {
                    KanclImage = "pillback4_lvl3.jpg";
                    OnPropertyChanged("KanclImage");
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        
    }
}
