using Autofac;
using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using HomeFinances.ViewModel.Helpers;
using HomeFinances.ViewModel.ViewModels;
using HomeFinances.XamarinForms.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.XamarinForms
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>();
            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>();
            builder.RegisterType<AddCategoryViewModel>().As<IAddCategoryViewModel>();
            builder.RegisterType<AddAccountViewModel>().As<IAddAccountViewModel>();
            builder.RegisterType<AddTransactionViewModel>().As<IAddTransactionViewModel>();
            builder.RegisterType<RecordsViewModel>().As<IRecordsViewModel>();
            builder.RegisterType<AppShell>().AsSelf();
            builder.RegisterType<HomePage>().AsSelf();
            builder.RegisterType<AddAccountPage>().AsSelf();
            builder.RegisterType<Configuration>().As<IConfiguration>();
            builder.RegisterType<DataChangedNotification>().AsSelf().SingleInstance();
            builder.RegisterType<AddTransactionPage>().AsSelf();

            return builder.Build();
        }
    }
}
