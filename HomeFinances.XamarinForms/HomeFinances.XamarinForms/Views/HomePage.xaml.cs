using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeFinances.ViewModel;
using HomeFinances.ViewModel.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinances.XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private IHomeViewModel ViewModel { get; }
        private AddAccountPage AddAccountPage { get; }
        private AddTransactionPage AddTransactionPage { get; }

        public HomePage(IHomeViewModel viewModel, AddAccountPage addAccountPage, AddTransactionPage addTransactionPage)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
            AddAccountPage = addAccountPage;
            AddTransactionPage = addTransactionPage;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(AddAccountPage);
        }

        private void AdjustBalanceButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(AddTransactionPage);
        }
    }
}