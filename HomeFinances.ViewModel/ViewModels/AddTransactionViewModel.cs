using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using HomeFinances.ViewModel.Events;
using HomeFinances.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public class AddTransactionViewModel : INotifyPropertyChanged, IAddTransactionViewModel
    {
        private TransactionType transactionType;
        private IDatabaseContext Context { get; }
        private DataChangedNotification DataChangedNotification { get; } 

        public List<Account> Accounts { get; private set; }
        public Account SelectedAccount { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }
        public ICommand AddTransactionCommand { get; }

        public TransactionType TransactionType
        {
            get => transactionType;
            set
            {
                transactionType = value;
                OnTransactionTypeChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddTransactionViewModel(IDatabaseContext context, ICommandFactory commandFactory, DataChangedNotification dataChangedNotification)
        {
            Context = context;
            DataChangedNotification = dataChangedNotification;
            DataChangedNotification.DataChanged += OnDataChanged;
            AddTransactionCommand = commandFactory.GetAddTransactionCommand(this);
            Date = DateTime.Now;
            LoadData();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnDataChanged(object sender, DataChangedEventArgs args)
        {
            await Task.Run(() => LoadData());
        }

        private void OnTransactionTypeChanged()
        {
            if (TransactionType == TransactionType.Expense)
            {
                Categories = Context.Categories.Where(x => x.Type == TransactionType.Expense).ToList();
            }
            else if (TransactionType == TransactionType.Income)
            {
                Categories = Context.Categories.Where(x => x.Type == TransactionType.Income).ToList();
            }
            else
            {
                Categories = new List<Category>();
            }

            RaisePropertyChanged("Categories");
        }

        private void LoadData()
        {
            if (!Context.Accounts.Any())
            {
                SelectedAccount = null;
                Accounts = new List<Account>();
            }
            else
            {
                Accounts = Context.Accounts.ToList();
                SelectedAccount = Accounts[0];
            }

            if (!Context.Categories.Any())
            {
                Categories = new List<Category>();
                transactionType = TransactionType.Expense;
            }
            else
            {
                Categories = Context.Categories.Where(x => x.Type == TransactionType.Expense).ToList();
                transactionType = TransactionType.Expense;
            }

            RaisePropertyChanged("AccountNames");
            RaisePropertyChanged("SelectedAccountIndex");
            RaisePropertyChanged("Categories");
        }

        public bool IsCategoryValid()
        {
            if (SelectedCategory == null) return false;
            if (SelectedCategory.Type == TransactionType) return true;
            return false;
        }

        public bool IsDateValid()
        {
            var compare = DateTime.Compare(Date, DateTime.Now);

            if (compare > 0) return false;
            else return true;
        }

        public bool IsValueValid()
        {
            float value;

            if (float.TryParse(Value, out value))
            {
                if (TransactionType == TransactionType.Expense)
                {
                    if (value >= 0) return false;
                    else return true;
                }
                else
                {
                    if (value <= 0) return false;
                    else return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void AddTransaction()
        {
            var account = Context.Accounts.Find(SelectedAccount.Id);
            Transaction transaction = null;

            if (TransactionType == TransactionType.Expense)
            {
                transaction = new Expense(Guid.NewGuid(), SelectedAccount.Id, Description, SelectedCategory, Date, float.Parse(Value));
            }
            else if (TransactionType == TransactionType.Income)
            {
                transaction = new Income(Guid.NewGuid(), SelectedAccount.Id, Description, SelectedCategory, Date, float.Parse(Value));
            }

            if (transaction != null)
            {
                account.Transactions.Add(transaction);
                Context.SaveChanges();
                DataChangedNotification.RaiseDataChanged("Transactions");
            }
        }
    }
}
