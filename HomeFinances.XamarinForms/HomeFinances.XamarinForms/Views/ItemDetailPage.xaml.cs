﻿using HomeFinances.XamarinForms.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HomeFinances.XamarinForms.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}