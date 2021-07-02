using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HomeFinances.ViewModel.Commands
{
    public class AddTransactionCommand : ICommand
    {
        private IAddTransactionViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;


        public AddTransactionCommand(IAddTransactionViewModel viewModel)
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
            if (ViewModel.IsCategoryValid() && ViewModel.IsDateValid() && ViewModel.IsValueValid()) return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            ViewModel.AddTransaction();
        }
    }
}
