using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeFinances.Model.Model
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private IConfiguration Configuration { get;  }

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlite($"Data Source={Configuration.DatabaseFilePath}");
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
