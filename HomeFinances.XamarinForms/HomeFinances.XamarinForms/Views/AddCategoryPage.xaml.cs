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
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryPage(IAddCategoryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}