using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.ViewModel.Events
{
    public class DataChangedEventArgs
    {
        public string TableName { get; }

        public DataChangedEventArgs(string tableName)
        {
            TableName = tableName;
        }
    }

    public delegate void DataChangedEventHandler(object sender, DataChangedEventArgs args);
}
