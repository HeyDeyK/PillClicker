using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Clicker.ViewModels
{
    class ViewModelSettings : UserData, INotifyPropertyChanged
    {
        public string ColorIbalgin { get; set; } = "Red";
        public string ColorParalen { get; set; } = "Red";

        public string IbalginEnabled { get; set; } = "true";
        public string ParalenEnabled { get; set; } = "true";
        ICommand cmdIbalgin;
        public ICommand CmdIbalgin
        {
            get { return cmdIbalgin; }
        }

        ICommand cmdParalen;
        public ICommand CmdParalen
        {
            get { return cmdParalen; }
        }

        public ViewModelSettings()
        {
            cmdIbalgin = new Command(UpgradeIbalgin);
            cmdParalen = new Command(UpgradeParalen);
            TimedFunctionShort(1000);
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
            if (10000 <= MoneyCTR)
            {
                ColorIbalgin = "Green";
                ColorParalen = "Green";
                OnPropertyChanged("ColorIbalgin");
                OnPropertyChanged("ColorParalen");
            }
            else
            {
                ColorIbalgin = "Red";
                ColorParalen = "Red";
                OnPropertyChanged("ColorIbalgin");
                OnPropertyChanged("ColorParalen");
            }

        }
        public void UpgradeIbalgin()
        {
            if(MoneyCTR>=10000)
            {
                MoneyCTR -= 10000;
                MoneyIncome = MoneyIncome + 20;
                IbalginEnabled = "false";
            }
        }
        public void UpgradeParalen()
        {
            if (MoneyCTR >= 10000)
            {
                MoneyCTR -= 10000;
                MoneyIncome = MoneyIncome + 20;
                ParalenEnabled = "false";
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
