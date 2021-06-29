using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public class AddAccountViewModel : IAddAccountViewModel
    {
        private IDatabaseContext Context { get; }

        public string Currency { get; set; }
        public string Name { get; set; }
        public string Balance { get; set; }
        public ICommand AddAccountCommand { get; }

        public AddAccountViewModel(IDatabaseContext context, ICommandFactory commandFactory)
        {
            Context = context;
            AddAccountCommand = commandFactory.GetAddAccountCommand(this);
        }

        public void AddAccount()
        {
            var account = new Account(Guid.NewGuid(), Currency, Name, double.Parse(Balance));
            Context.Accounts.Add(account);
            Context.SaveChanges();
        }
    }
}
