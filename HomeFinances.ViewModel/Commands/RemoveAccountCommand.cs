using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HomeFinances.ViewModel.Commands
{
    public class RemoveAccountCommand : ICommand
    {
        private IHomeViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;

        public RemoveAccountCommand(IHomeViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "SelectedAccount") return;

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (ViewModel.SelectedAccount != null) return true;
            else return false;
        }

        public void Execute(object parameter)
        {
            ViewModel.RemoveSelectedAccount();
        }
    }
}
