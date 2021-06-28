using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinances.ViewModel.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        private int? selectedAccountIndex;
        private DatabaseContext Context { get; }
        
        public string Cash { get; private set; }
        public List<string> AccountNames { get; private set; }
        public int? SelectedAccountIndex 
        { 
            get => selectedAccountIndex; 
            set
            {
                if (selectedAccountIndex >= Context.Accounts.ToList().Count) throw new ArgumentOutOfRangeException("Account index");
                selectedAccountIndex = value;
                OnPropertyChanged("SelectedAccountIndex");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel(DatabaseContext context)
        {
            Context = context;
            Context.DataChanged += OnDataChanged;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnDataChanged(object sender, EventArgs args)
        {
            await Task.Run(() => LoadData());
        }

        private void LoadData()
        {
            if(!Context.Accounts.Any())
            {
                SelectedAccountIndex = null;
                Cash = "0";
                AccountNames = new List<string>();
            }
            else
            {
                AccountNames = Context.Accounts.Select(x => x.Name).ToList();
                var accounts = Context.Accounts.ToList();
                SelectedAccountIndex = 0;
                Cash = accounts[0].Balance.ToString() + " " + accounts[0].Currency;
            }
        }

        public void AdjustBalance(double newBalance)
        {
            if (!SelectedAccountIndex.HasValue) return;
            if(Context.Accounts.ToList().Count > SelectedAccountIndex.Value)
            {
                Context.Accounts.ElementAt(SelectedAccountIndex.Value).Balance = newBalance;
                Context.SaveChanges();
            }
        }
    }
}
