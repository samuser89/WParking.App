﻿using System;
using WParking.App.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WParking.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage()); ;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}