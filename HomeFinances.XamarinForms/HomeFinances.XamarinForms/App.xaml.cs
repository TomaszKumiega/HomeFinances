using Autofac;
using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using HomeFinances.ViewModel.ViewModels;
using HomeFinances.XamarinForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinances.XamarinForms
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var container = ContainerConfig.Configure();
            MainPage = container.Resolve<AppShell>();
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
