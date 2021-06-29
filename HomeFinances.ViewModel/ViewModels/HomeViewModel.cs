using HomeFinances.ViewModel.Events;
using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HomeFinances.ViewModel.Commands;

namespace HomeFinances.ViewModel.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged, IHomeViewModel
    {

        private Account selectedAccount;
        private IDatabaseContext Context { get; }
        private DataChangedNotification DataChangedNotification { get; }

        public ICommand RemoveAccountCommand { get; }
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

        public HomeViewModel(IDatabaseContext context, DataChangedNotification dataChangedNotification, ICommandFactory commandFactory)
        {
            Context = context;
            DataChangedNotification = dataChangedNotification;
            RemoveAccountCommand = commandFactory.GetRemoveAccountCommand(this);
            DataChangedNotification.DataChanged += OnDataChanged;
            LoadData();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnDataChanged(object sender, DataChangedEventArgs args)
        {
            if (args.TableName != "Accounts") return;

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
            RaisePropertyChanged("SelectedAccount");
            RaisePropertyChanged("Cash");
        }

        public void AdjustBalance(double newBalance)
        {
            if (SelectedAccount == null) return;

            SelectedAccount.Balance = newBalance;
            Context.SaveChanges();
        }

        public void RemoveSelectedAccount()
        {
            if (SelectedAccount == null) return;

            Context.Accounts.Remove(SelectedAccount);
            Context.SaveChanges();
        }
    }
}
