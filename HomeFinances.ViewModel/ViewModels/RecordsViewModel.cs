using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinances.ViewModel.ViewModels
{
    public enum Period
    {
        Week,
        Month,
        Days90,
        Months6,
        Year
    }

    public class RecordsViewModel : INotifyPropertyChanged, IRecordsViewModel
    {
        private IDatabaseContext Context { get; }
        private Account selectedAccount;
        private Category selectedCategory;
        private Period period;
        private TransactionType? transactionType;

        public List<Account> Accounts { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Transaction> DisplayedTransactions { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Account SelectedAccount
        {
            get => selectedAccount;
            set
            {
                selectedAccount = value;
                RaisePropertyChanged("SelectedAccount");
            }
        }

        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        public Period Period
        {
            get => period;
            set
            {
                period = value;
                RaisePropertyChanged("Period");
            }
        }

        public TransactionType? TransactionType
        {
            get => transactionType;
            set
            {
                transactionType = value;
                RaisePropertyChanged("TransactionType");
            }
        }

        public RecordsViewModel(IDatabaseContext context)
        {
            Context = context;
            Period = Period.Days90;
            LoadData();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            await Task.Run(() => LoadTransactions());
        }

        private void LoadAccountsList()
        {
            if (!Context.Accounts.Any())
            {
                SelectedAccount = null;
                Accounts = new List<Account>();
            }
            else
            {
                SelectedAccount = null;
                Accounts = Context.Accounts.ToList();
            }
        }

        private void LoadCategoriesList()
        {
            if (!Context.Categories.Any())
            {
                SelectedCategory = null;
                Categories = new List<Category>();
            }
            else
            {
                SelectedCategory = null;
                if (TransactionType.HasValue)
                {
                    if (TransactionType.Value == Model.Model.TransactionType.Expense)
                    {
                        Categories = Context.Categories.Where(x => x.Type == Model.Model.TransactionType.Expense).ToList();
                    }
                    else if (TransactionType.Value == Model.Model.TransactionType.Income)
                    {
                        Categories = Context.Categories.Where(x => x.Type == Model.Model.TransactionType.Income).ToList();
                    }
                }
                else
                {
                    Categories = Context.Categories.ToList();
                }
            }
        }

        private void LoadTransactions()
        {
            SelectTransactionsFromSpecifiedPeriod();
            SelectTransactionsWithSelectedAccount();
            SelectTransactionsWithSelectedTransactionType();
            SelectTransactionsWithSelectedCategory();
        }

        private void SelectTransactionsFromSpecifiedPeriod()
        {
            DateTime datetime = DateTime.Now;

            switch (Period)
            {
                case Period.Week:
                    datetime = DateTime.Now.AddDays(-7);
                    break;
                case Period.Month:
                    datetime = DateTime.Now.AddMonths(-1);
                    break;
                case Period.Days90:
                    datetime = DateTime.Now.AddDays(-90);
                    break;
                case Period.Months6:
                    datetime = DateTime.Now.AddMonths(-6);
                    break;
                case Period.Year:
                    datetime = DateTime.Now.AddYears(-1);
                    break;
            }

            DisplayedTransactions = new List<Transaction>();
            DisplayedTransactions = Context.Transactions.Where(x => (DateTime.Compare(datetime, DateTime.Now) <= 0)).ToList();
        }

        private void SelectTransactionsWithSelectedCategory()
        {
            if (SelectedCategory != null)
            {
                DisplayedTransactions = DisplayedTransactions.Where(x => x.Category.Id == SelectedCategory.Id).ToList();
            }
        }

        private void SelectTransactionsWithSelectedTransactionType()
        {
            if (TransactionType.HasValue)
            {
                if (TransactionType.Value == Model.Model.TransactionType.Expense)
                {
                    DisplayedTransactions = DisplayedTransactions.Where(x => x.Discriminator == "Expense").ToList();
                }
                else if (TransactionType.Value == Model.Model.TransactionType.Income)
                {
                    DisplayedTransactions = DisplayedTransactions.Where(x => x.Discriminator == "Income").ToList();
                }
            }
        }

        private void SelectTransactionsWithSelectedAccount()
        {
            if (SelectedAccount != null)
            {
                DisplayedTransactions = DisplayedTransactions.Where(x => x.AccountId == SelectedAccount.Id).ToList();
            }
        }

        private void LoadData()
        {
            LoadAccountsList();
            LoadCategoriesList();
            LoadTransactions();
        }
    }
}
