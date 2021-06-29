using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public class Income : Transaction
    {
        private float _value;
        private Category _category;

        public Income()
        {

        }

        public Income(Guid id, Guid accountId, string desctription, Category category, DateTime dateTime, float value)
        {
            Id = id;
            AccountId = accountId;
            Description = desctription;
            Category = category;
            Date = dateTime;
            Value = value;
        }

        public override float Value
        {
            get => _value;
            set
            {
                if (value <= 0) throw new ArgumentException("Value cannot be negative or 0");
                _value = value;
            }
        }

        public override Category Category
        {
            get => _category;
            set
            {
                if (value.Type != TransactionType.Expense) throw new ArgumentException("Category type must be IncomeCategory");
                _category = value;
            }
        }
    }
}
