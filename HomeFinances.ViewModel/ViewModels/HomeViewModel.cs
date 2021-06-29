using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinances.ViewModel.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged, IHomeViewModel
    {

        private Account selectedAccount;
        private IDatabaseContext Context { get; }

        public string Cash { get; private set; }
        public List<Account> Accounts { get; private set; }
        public Account SelectedAccount
        {
            get => selectedAccount;
            set
            {
                selectedAccount = value;
                OnSelectedAccountChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel(IDatabaseContext context)
        {
            Context = context;
            Context.DataChanged += OnDataChanged;
            LoadData();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnDataChanged(object sender, EventArgs args)
        {
            await Task.Run(() => LoadData());
        }

        private void LoadData()
        {
            if (!Context.Accounts.Any())
            {
                SelectedAccount = null;
                Cash = "0";
                Accounts = new List<Account>();
            }
            else
            {
                Accounts = Context.Accounts.ToList();
                SelectedAccount = Accounts[0];
                Cash = Accounts[0].Balance.ToString() + " " + Accounts[0].Currency;
            }

            RaisePropertyChanged("Cash");
            RaisePropertyChanged("Accounts");
        }

        private void OnSelectedAccountChanged()
        {
            if (SelectedAccount == null) return;

            Cash = SelectedAccount.Balance.ToString() + " " + SelectedAccount.Currency;
        }

        public void AdjustBalance(double newBalance)
        {
            if (SelectedAccount == null) return;

            SelectedAccount.Balance = newBalance;
            Context.SaveChanges();
        }
    }
}
