using HomeFinances.Model.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IRecordsViewModel
    {
        List<Account> Accounts { get; }
        List<Category> Categories { get; }
        List<Transaction> DisplayedTransactions { get; }
        Period Period { get; set; }
        Account SelectedAccount { get; set; }
        Category SelectedCategory { get; set; }
        TransactionType? TransactionType { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}