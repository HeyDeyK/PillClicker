using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clicker
{
    class AppViewModel : INotifyPropertyChanged
    {
        double money = 0;
        int lekySekunda = 0;
        


        private string _LekyCTR= "0";
        public string LekyCTR
        {
            get => _LekyCTR;
            set
            {
                _LekyCTR = value;
            }
        }

        private string _MoneyCTR = "0";
        public string MoneyCTR
        {
            get => _MoneyCTR;
            set
            {
                _MoneyCTR = value;
            }
        }

        private string _LekyIncome = "0";
        public string LekyIncome
        {
            get => _LekyIncome;
            set
            {
                _LekyIncome = value;
            }
        }

        private int _TovarnaPrice = 5;
        public int TovarnaPrice
        {
            get => _TovarnaPrice;
            set
            {
                _TovarnaPrice = value;
            }
        }
        private int _TovarnaIncome = 0;
        public int TovarnaIncome
        {
            get => _TovarnaIncome;
            set
            {
                _TovarnaIncome = value;
            }
        }
        public string TovarnaColor { get; set; } = "red";



        ICommand tapCommand;
        ICommand tovarnaUpgrade;
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        public ICommand TovarnaUpgrade
        {
            get { return tovarnaUpgrade; }
        }


        public AppViewModel()
        {
            // configure the TapCommand with a method
            tapCommand = new Command(OnTapped);
            tovarnaUpgrade = new Command(AutoFactory);
            TimedFunction(1000);
            

        }
        public void TimedFunction(int cas)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = cas;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            /*if(lekySekunda<5 && lekySekunda>0)
            {
                lekySekunda = 4;
            }*/
            //double cislo = 2 / 4;
            money = money + lekySekunda; // 1;
            LekyCTR = "" + money;
            OnPropertyChanged("LekyCTR");
            CheckButtonsPrices();
        }
        private void CheckButtonsPrices()
        {
            if(TovarnaPrice<=money)
            {
                TovarnaColor = "Green";
                OnPropertyChanged("TovarnaColor");
            }
            else
            {
                TovarnaColor = "Red";
                OnPropertyChanged("TovarnaColor");
            }
        }
        void OnTapped(object s)
        {
            money++;
            LekyCTR = "" + money;
            OnPropertyChanged("LekyCTR");

        }
        void AutoFactory(object s)
        {
            if(money>=TovarnaPrice)
            {
                money = money - TovarnaPrice;
                TovarnaIncome = ((TovarnaIncome + 1) * 2);
                TovarnaPrice = ((TovarnaIncome * 10) + 10);
                lekySekunda = TovarnaIncome;
                LekyIncome = " " + lekySekunda + " p/s";
                Console.WriteLine(LekyIncome);
                OnPropertyChanged("LekyIncome");
                OnPropertyChanged("TovarnaPrice");
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
