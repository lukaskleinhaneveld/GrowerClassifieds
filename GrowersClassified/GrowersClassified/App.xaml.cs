﻿using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using GrowersClassified.Views.Menu;
using System.Threading;
using System.Data;

namespace GrowersClassified
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MasterDetail());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
