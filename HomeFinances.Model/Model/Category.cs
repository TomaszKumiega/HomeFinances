using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;

namespace HomeFinances.Model.Model
{ 
    public enum TransactionType
    {
        Expense,
        Income
    }

    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public Color Color { get; set; }
        public Int32 ArgbColor
        {
            get => Color.ToArgb();
            set => Color = Color.FromArgb(value);
        }
        public TransactionType Type { get; set; }
    }
}
