﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Clicker.ViewModels;
using System.IO;
using CsvHelper;

namespace Clicker
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.BindingContext = new AppViewModel();
            

        }
        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;
            // Do something
            DisplayAlert("Alert", "Tap gesture recoganised", "OK");
        }
        void TapOpenLab(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new SettingsPage { });
        }
        void TapOpenSettings(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new SettingsPage { });
        }
        void TapOpenUpgrade(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new Page3 { });
        }
        
    }
}
