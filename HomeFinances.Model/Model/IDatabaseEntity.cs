using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public interface IDatabaseEntity
    {
        Guid Id { get; set; }
    }
}
