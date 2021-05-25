﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model
{
    public abstract class Transaction
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual float Value { get; set; }
    }
}