using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HomeFinances.ViewModel.Commands
{
    public class AddAccountCommand : ICommand
    {
        private IAddAccountViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;

        public AddAccountCommand(IAddAccountViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (String.IsNullOrEmpty(ViewModel.Name) || String.IsNullOrEmpty(ViewModel.Currency) || String.IsNullOrEmpty(ViewModel.Balance)) return false;
            else return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.AddAccount();
        }
    }
}
