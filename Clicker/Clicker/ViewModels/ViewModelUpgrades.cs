using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clicker.ViewModels
{
    class ViewModelUpgrades : UserData, INotifyPropertyChanged
    {
        ICommand cmdUpgradeKlik;
        public ICommand CmdUpgradeKlik
        {
            get { return cmdUpgradeKlik; }
        }
        ICommand cmdUpgradeDoubleMinuta;
        public ICommand CmdUpgradeDoubleMinuta
        {
            get { return cmdUpgradeDoubleMinuta; }
        }
        ICommand cmdUpgradeDoubleDeset;
        public ICommand CmdUpgradeDoubleDeset
        {
            get { return cmdUpgradeDoubleDeset; }
        }
        ICommand cmdUpgradeDoublePerma;
        public ICommand CmdUpgradeDoublePerma
        {
            get { return cmdUpgradeDoublePerma; }
        }

        public string UpgradeKlikColor { get; set; } = "red";
        public string UpgradeDoubleMinutaColor { get; set; } = "red";
        public string UpgradeDoubleDesetColor { get; set; } = "red";
        public string UpgradeDoublePermaColor { get; set; } = "red";
        public ViewModelUpgrades()
        {
            cmdUpgradeKlik =  new Command(UpgradeKlik);
            cmdUpgradeDoubleMinuta = new Command(UpgradeDoubleMinuta);
            cmdUpgradeDoubleDeset = new Command(UpgradeDoubleDeset);
            cmdUpgradeDoublePerma = new Command(UpgradeDoublePerma);
            UpgKlikLevel = "" + KlikLevel;
            OnPropertyChanged("UpgKlikLevel");
            TimedFunctionShort(250);
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
            if (KlikPrice <= MoneyCTR)
            {
                UpgradeKlikColor = "Green";
                OnPropertyChanged("UpgradeKlikColor");
            }
            else
            {
                UpgradeKlikColor = "Red";
                OnPropertyChanged("UpgradeKlikColor");
            }
            if (DoubleKlikMinutaPrice <= MoneyCTR)
            {
                UpgradeDoubleMinutaColor = "Green";
                OnPropertyChanged("UpgradeDoubleMinutaColor");
            }
            else
            {
                UpgradeDoubleMinutaColor = "Red";
                OnPropertyChanged("UpgradeDoubleMinutaColor");
            }
            if (DoubleKlikDesetPrice <= MoneyCTR)
            {
                UpgradeDoubleDesetColor = "Green";
                OnPropertyChanged("UpgradeDoubleDesetColor");
            }
            else
            {
                UpgradeDoubleDesetColor = "Red";
                OnPropertyChanged("UpgradeDoubleDesetColor");
            }
        }

        void UpgradeKlik()
        {
            if(MoneyCTR>= KlikPrice)
            {
                KlikLevel++;
                
                MoneyClick++;
                Console.WriteLine(MoneyClick);
                KlikPrice += 1000;
                UpgKlikLevel = "" + KlikLevel;
                MoneyCTR -= KlikPrice;
                OnPropertyChanged("UpgKlikLevel");
                OnPropertyChanged("KlikPrice");
            } else
            {
            }
            

        }
        public void UpgradeDoublePerma()
        {

        }
        public async void UpgradeDoubleMinuta()
        {
            
            if(DoubleKlikMinutaDuration==0)
            {
                DoubleKlikMinutaDuration += 60;
                Console.WriteLine("CS pridavam");
                MoneyClick = MoneyClick * 2;
                while (true)
                {
                    await Task.Delay(1000);
                    DoubleKlikMinutaDuration--;

                    DoubleKlikMinutaZbyva = TimeSpan.FromSeconds(DoubleKlikMinutaDuration).ToString(@"mm\:ss");
                    OnPropertyChanged("DoubleKlikMinutaZbyva");
                    if (DoubleKlikMinutaDuration == 0)
                    {
                        DoubleKlikMinutaDuration = 60;
                        MoneyClick = MoneyClick / 2;
                        break;

                    }
                }
            }
            else
            {
                DoubleKlikMinutaDuration += 60;
            }
            // tick every second while game is in progress
            
        }
        public async void UpgradeDoubleDeset()
        {
            if (DoubleKlikDesetDuration== 0)
            {
                DoubleKlikDesetDuration += 600;
                MoneyClick = MoneyClick * 2;
                while (true)
                {
                    await Task.Delay(1000);
                    DoubleKlikDesetDuration--;

                    DoubleKlikDesetDurationZbyva = TimeSpan.FromSeconds(DoubleKlikDesetDuration).ToString(@"mm\:ss");
                    OnPropertyChanged("DoubleKlikDesetDurationZbyva");
                    if (DoubleKlikDesetDuration == 0)
                    {
                        DoubleKlikDesetDuration = 600;
                        MoneyClick = MoneyClick / 2;
                        break;

                    }
                }
            }
            else
            {
                DoubleKlikDesetDuration += 600;
            }
            // tick every second while game is in progress
            
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
