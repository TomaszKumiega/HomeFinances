using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public abstract class Transaction
    {
        public virtual Guid Id { get; set; }
        public virtual Guid AccountId { get; set; }
        public virtual string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual float Value { get; set; }
        public string Discriminator { get; private set; }
    }
}
