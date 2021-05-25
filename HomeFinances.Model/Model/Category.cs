using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HomeFinances.Model.Model
{ 
    public enum CategoryType
    {
        IncomeCategory,
        ExpenseCategory
    }

    public class Category : IDatabaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public CategoryType Type { get; set; }
    }
}
