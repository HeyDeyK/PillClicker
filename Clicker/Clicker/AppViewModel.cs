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
        double taps = 0;
        int intLeky = 0;
        private string _LekyCTR= "0";
        public string LekyCTR
        {
            get => _LekyCTR;
            set
            {
                _LekyCTR = value;
            }
        }
        private string _AutoLeky = "0";
        public string AutoLeky
        {
            get => _AutoLeky;
            set
            {
                _AutoLeky = value;
            }
        }
        ICommand tapCommand;
        ICommand upgradeFactory;
        public AppViewModel()
        {
            // configure the TapCommand with a method
            tapCommand = new Command(OnTapped);
            upgradeFactory = new Command(AutoFactory);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 250;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;

        }
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Origo:" + intLeky);
            double cislo = intLeky / 4;
            taps = taps + intLeky;
            LekyCTR = "" + taps;
            OnPropertyChanged("LekyCTR");
        }
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        public ICommand UpgradeFactory
        {
            get { return upgradeFactory; }
        }
        void OnTapped(object s)
        {
            taps++;
            Console.WriteLine(taps);
            LekyCTR = "" + taps;
            OnPropertyChanged("LekyCTR");

        }
        void AutoFactory(object s)
        {
            intLeky = ((intLeky + 1) * 2);
            AutoLeky = " "+ ((intLeky + 1) * 2);
            Console.WriteLine(AutoLeky);
            OnPropertyChanged("AutoLeky");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        void TapF()
        {
            Console.WriteLine("Test");
        }
        
    }
}
