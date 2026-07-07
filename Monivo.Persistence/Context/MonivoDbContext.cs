using Microsoft.EntityFrameworkCore;
using Monivo.Domain.Entities;

namespace Monivo.Persistence.Context
{
    public class MonivoDbContext : DbContext
    {
        public MonivoDbContext(DbContextOptions<MonivoDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<RecurringTransaction> RecurringTransactions { get; set; }
        public DbSet<MonthlyBudget> MonthlyBudgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MonivoDbContext).Assembly);
        }
    }
}
