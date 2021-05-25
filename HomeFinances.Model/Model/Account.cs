using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public class Account : IDatabaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
