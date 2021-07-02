using HomeFinances.Model.Model;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Input;

namespace HomeFinances.ViewModel.ViewModels
{
    public interface IAddCategoryViewModel
    {
        ICommand AddCategoryCommand { get; set; }
        Color Color { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        TransactionType TransactionType { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void AddCategory();
    }
}