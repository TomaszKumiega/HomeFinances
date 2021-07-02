using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
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
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.AddTransaction();
        }
    }
}
