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
            RegisterTypes();
            MainPage = new AppShell();
        }

        private void RegisterTypes()
        {
            DependencyService.Register<IDatabaseContext, DatabaseContext>();
            DependencyService.Register<ICommandFactory, CommandFactory>();
            DependencyService.Register<IHomeViewModel, HomeViewModel>();
            DependencyService.Register<IAddAccountViewModel, AddAccountViewModel>();
            DependencyService.Register<IAddTransactionViewModel, AddTransactionViewModel>();
            DependencyService.Register<IRecordsViewModel, RecordsViewModel>();
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
