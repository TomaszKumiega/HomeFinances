using HomeFinances.Model.Model;
using HomeFinances.ViewModel.Commands;
using HomeFinances.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public class AddCategoryViewModel : INotifyPropertyChanged, IAddCategoryViewModel
    {
        private IDatabaseContext Context { get; }
        private DataChangedNotification DataChangedNotification { get; }
        private string name;
        private string description;
        private Color color;
        private TransactionType transactionType;

        public ICommand AddCategoryCommand { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }

        public TransactionType TransactionType
        {
            get => transactionType;
            set
            {
                transactionType = value;
                RaisePropertyChanged("TransactionType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCategoryViewModel(IDatabaseContext databaseContext, DataChangedNotification dataChangedNotification, ICommandFactory commandFactory)
        {
            Context = databaseContext;
            DataChangedNotification = dataChangedNotification;
            AddCategoryCommand = commandFactory.GetAddCategoryCommand(this);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCategory()
        {
            var category = new Category(Guid.NewGuid(), Name, Description, Color, TransactionType);
            Context.Categories.Add(category);
            Context.SaveChanges();
            DataChangedNotification.RaiseDataChanged("Categories");
        }
    }
}
