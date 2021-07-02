using HomeFinances.XamarinForms.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HomeFinances.XamarinForms
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell(HomePage homePage, RecordsPage recordsPage, StatisticsPage statisticsPage)
        {
            InitializeComponent();
            HomeShellContent.Content = homePage;
            RecordsShellContent.Content = recordsPage;
            StatisticsShellContent.Content = statisticsPage;
        }
    }
}
