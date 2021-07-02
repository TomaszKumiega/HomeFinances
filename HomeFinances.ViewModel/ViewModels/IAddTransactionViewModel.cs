using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IAddTransactionViewModel
    {
        List<Account> Accounts { get; }
        ICommand AddTransactionCommand { get; }
        List<Category> Categories { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
        Account SelectedAccount { get; set; }
        Category SelectedCategory { get; set; }
        int Type { get; set; }
        string Value { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void AddTransaction();
        bool IsCategoryValid();
        bool IsDateValid();
        bool IsValueValid();
    }
}