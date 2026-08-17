using Microsoft.EntityFrameworkCore;
using Monivo.Domain.Common;
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

        public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
