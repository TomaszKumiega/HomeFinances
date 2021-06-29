using HomeFinances.Model.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeFinances.XamarinForms
{
    public class Configuration : IConfiguration
    {
        public string DatabaseFilePath 
        {
            get
            {
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var databasePath = Path.Combine(folderPath, this.DatabaseFileName);
                return databasePath;
            } 
        }

        public string DatabaseFileName
        {
            get => "HomeFinances.db";
        }
    }
}
