using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public class AddAccountViewModel : IAddAccountViewModel, INotifyPropertyChanged
    {
        private IDatabaseContext Context { get; }
        private string currency;
        private string name;
        private string balance;


        public string Currency 
        { 
            get => currency; 
            set
            {
                currency = value;
                RaisePropertyChanged("Currency");
            }
        }
        public string Name 
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Balance 
        { 
            get => balance; 
            set
            {
                balance = value;
                RaisePropertyChanged("Balance");
            }
        }

        public ICommand AddAccountCommand { get; }

        public AddAccountViewModel(IDatabaseContext context, ICommandFactory commandFactory)
        {
            Context = context;
            AddAccountCommand = commandFactory.GetAddAccountCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddAccount()
        {
            var account = new Account(Guid.NewGuid(), Currency, Name, double.Parse(Balance));
            Context.Accounts.Add(account);
            Context.SaveChanges();
        }
    }
}
