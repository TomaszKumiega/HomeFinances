using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public interface IConfiguration
    {
        string DatabaseFilePath { get; }
    }
}
