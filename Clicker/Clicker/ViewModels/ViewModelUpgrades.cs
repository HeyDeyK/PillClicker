using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clicker.ViewModels
{
    class ViewModelUpgrades : UserData, INotifyPropertyChanged
    {
        public int KlikLevel { get; set; } = 1;
        public string UpgKlikLevel { get; set; } = "";

        public int KlikPrice { get; set; } = 200;

        ICommand cmdUpgradeKlik;
        public ICommand CmdUpgradeKlik
        {
            get { return cmdUpgradeKlik; }
        }
        public ViewModelUpgrades()
        {
            cmdUpgradeKlik =  new Command(UpgradeKlik);
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
            
        }

        void UpgradeKlik()
        {
            if(MoneyCTR>= KlikPrice)
            {
                Console.WriteLine("Jdeme na to");
                KlikLevel++;
                KlikPrice += 200;
                UpgKlikLevel = "" + KlikLevel;
                MoneyCTR -= KlikPrice;
                OnPropertyChanged("UpgKlikLevel");
                OnPropertyChanged("KlikPrice");
            } else
            {
                Console.WriteLine("NO CASH");
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
