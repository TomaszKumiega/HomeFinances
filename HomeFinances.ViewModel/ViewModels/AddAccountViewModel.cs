using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.ViewModel.ViewModels
{
    public class AddAccountViewModel
    {
        private IDatabaseContext Context { get; }

        public string Currency { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public AddAccountViewModel(IDatabaseContext context)
        {
            Context = context;
        }

        public void AddAccount()
        {
            var account = new Account(Guid.NewGuid(), Currency, Name, Balance);
            Context.Accounts.Add(account);
            Context.SaveChanges();
        }
    }
}
