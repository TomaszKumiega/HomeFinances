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

        public HomePage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Resolve<IHomeViewModel>();
        }
    }
}