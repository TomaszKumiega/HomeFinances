using HomeFinances.Model.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IHomeViewModel
    {
        List<Account> Accounts { get; }
        string Cash { get; }
        Account SelectedAccount { get; set; }
        ICommand RemoveAccountCommand { get; }

        event PropertyChangedEventHandler PropertyChanged;

        void AdjustBalance(double newBalance);
        void RemoveSelectedAccount();
    }
}