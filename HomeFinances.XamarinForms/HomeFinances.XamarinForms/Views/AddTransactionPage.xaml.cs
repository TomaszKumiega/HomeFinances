using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinances.XamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTransactionPage : ContentPage
    {
        private AddCategoryPage AddCategoryPage { get; set; }
        public AddTransactionPage(IAddTransactionViewModel viewModel, AddCategoryPage addCategoryPage)
        {
            AddCategoryPage = addCategoryPage;
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(AddCategoryPage);
        }

        private async void AddTransactionButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}