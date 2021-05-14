using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model
{
    public abstract class Transaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
    }
}
