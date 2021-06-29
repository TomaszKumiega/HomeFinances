using HomeFinances.ViewModel.ViewModels;

namespace HomeFinances.ViewModel.Commands
{
    public interface ICommandFactory
    {
        AddAccountCommand GetAddAccountCommand(IAddAccountViewModel viewModel);
        AddTransactionCommand GetAddTransactionCommand(IAddTransactionViewModel viewModel);
        RemoveAccountCommand GetRemoveAccountCommand(IHomeViewModel viewModel);
    }
}