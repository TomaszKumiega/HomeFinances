using HomeFinances.Model.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.ViewModel.Helpers
{
    public class DataChangedNotification
    {
        public event DataChangedEventHandler DataChanged;

        public void RaiseDataChanged(string tableName)
        {
            DataChanged?.Invoke(this, new DataChangedEventArgs(tableName));
        }
    }
}
