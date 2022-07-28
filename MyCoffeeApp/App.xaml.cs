//using MyCoffeeApp.Services;
using MonkeyCache.FileStore;
using MyCoffeeApp.Views;
using MyCoffeeApp.Helpers;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            TheTheme.SetTheme();

            Barrel.ApplicationId = AppInfo.PackageName;

            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            OnResume();
        }
        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }
        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }
        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
