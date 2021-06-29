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
    }
}
