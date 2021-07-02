using System;
using System.Collections.Generic;
using System.Text;

namespace HomeFinances.Model.Model
{
    public class Account
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }

        public Account(Guid id, string currency, string name, double balance)
        {
            Id = id;
            Currency = currency;
            Name = name;
            Balance = balance;
            Transactions = new List<Transaction>();
        }

        public Guid Id { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
