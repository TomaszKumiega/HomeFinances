using System.Collections.Generic;
using System.ComponentModel;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IHomeViewModel
    {
        List<string> AccountNames { get; }
        string Cash { get; }
        int? SelectedAccountIndex { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void AdjustBalance(double newBalance);
    }
}