using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using HomeFinances.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeFinances.GUI
{
    public static class DIConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            #region Model
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>();
            #endregion

            #region ViewModel
            builder.RegisterType<CommandFactory>().As<ICommandFactory>();
            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>();
            builder.RegisterType<AddAccountViewModel>().As<IAddAccountViewModel>();
            #endregion


            return builder.Build();
        }
    }
}