using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public class Income : Transaction
    {
        private float _value;
        private Category _category;

        public override float Value
        {
            get => _value;
            set
            {
                if (value < 0) throw new ArgumentException("Value cannot be negative");
                _value = value;
            }
        }

        public override Category Category
        {
            get => _category;
            set
            {
                if (value.Type != CategoryType.IncomeCategory) throw new ArgumentException("Category type must be IncomCategory");
                _category = value;
            }
        }
    }
}
