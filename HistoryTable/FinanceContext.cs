using System;
using Microsoft.EntityFrameworkCore;

namespace HistoryTable
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
        {
            Console.WriteLine("Context created");
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Console.WriteLine("OnModelCreating");
        }
    }
}