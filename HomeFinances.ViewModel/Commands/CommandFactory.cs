using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.ViewModel.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public AddAccountCommand GetAddAccountCommand(IAddAccountViewModel viewModel)
        {
            return new AddAccountCommand(viewModel);
        }

        public AddCategoryCommand GetAddCategoryCommand(IAddCategoryViewModel viewModel)
        {
            return new AddCategoryCommand(viewModel);
        }

        public AddTransactionCommand GetAddTransactionCommand(IAddTransactionViewModel viewModel)
        {
            return new AddTransactionCommand(viewModel);
        }

        public RemoveAccountCommand GetRemoveAccountCommand(IHomeViewModel viewModel)
        {
            return new RemoveAccountCommand(viewModel);
        }
    }
}
