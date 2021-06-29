using HomeFinances.Model.Model;
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
            RegisterTypes();
            MainPage = new AppShell();
        }

        private void RegisterTypes()
        {
            DependencyService.Register<IDatabaseContext, DatabaseContext>();
            DependencyService.Register<IHomeViewModel, HomeViewModel>();
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
