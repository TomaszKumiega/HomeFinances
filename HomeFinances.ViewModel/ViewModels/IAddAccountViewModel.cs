using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IAddAccountViewModel
    {
        ICommand AddAccountCommand { get; }
        string Balance { get; set; }
        string Currency { get; set; }
        string Name { get; set; }

        void AddAccount();
    }
}