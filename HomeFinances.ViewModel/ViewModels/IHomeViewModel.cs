﻿using HomeFinances.Model.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IHomeViewModel
    {
        List<Account> Accounts { get; }
        string Cash { get; }
        Account SelectedAccount { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void AdjustBalance(double newBalance);
    }
}