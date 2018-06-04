using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clicker
{
    class AppViewModel : INotifyPropertyChanged
    {

        

        private int _MoneyCTR = 50;
        public int MoneyCTR
        {
            get => _MoneyCTR;
            set
            {
                _MoneyCTR = value;
            }
        }
        private int _MoneyIncome = 0;
        public int MoneyIncome
        {
            get => _MoneyIncome;
            set
            {
                _MoneyIncome = value;
            }
        }

        private int _TovarnaPrice = 50;
        public int TovarnaPrice
        {
            get => _TovarnaPrice;
            set
            {
                _TovarnaPrice = value;
            }
        }
        private int _TovarnaCount = 1;
        public int TovarnaCount
        {
            get => _TovarnaCount;
            set
            {
                _TovarnaCount = value;
            }
        }
        private int _ProdejnaPrice = 50;
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
        private int _LabPrice = 50;
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
        private int _KanclPrice = 50;
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
            TimedFunction(1000);
            TimedFunctionShort(250);
        }
        private void AddCommands()
        {
            tovarnaUpgrade = new Command(AutoFactory);
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
            MoneyCTR++;
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

            MoneyCTR = MoneyCTR + MoneyIncome;
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
        
        void AutoFactory(object s)
        {
            if(MoneyCTR>=TovarnaPrice)
            {
                TovarnaCount++;
                MoneyCTR = MoneyCTR - TovarnaPrice;
                MoneyIncome = TovarnaCount * 5;
                double NewPrice = TovarnaPrice * Math.Pow(1.1,TovarnaCount);
                Console.WriteLine(NewPrice);
                TovarnaPrice = Convert.ToInt32(NewPrice);
                
                OnPropertyChanged("TovarnaPrice");
                OnPropertyChanged("MoneyCTR");
                OnPropertyChanged("MoneyIncome");
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
