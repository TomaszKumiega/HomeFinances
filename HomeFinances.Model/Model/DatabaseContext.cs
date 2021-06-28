using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeFinances.Model.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Database/HomeFinances.db");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasMany(x => x.Transactions);
            builder.Entity<Account>()
                .ToTable("Accounts")
                .HasKey(x => x.Id);

            builder.Entity<Expense>();
            builder.Entity<Income>();

            builder.Entity<Transaction>()
                .HasDiscriminator<string>("TransactionType");
            builder.Entity<Transaction>()
                .HasOne(x => x.Category);
                
            builder.Entity<Category>()
                .ToTable("Categories");
        }
    }
}
