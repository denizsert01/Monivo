using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Persistence.Configurations
{
    public sealed class MonthlyBudgetConfiguration : IEntityTypeConfiguration<MonthlyBudget>
    {
        public void Configure(EntityTypeBuilder<MonthlyBudget> builder)
        {
            builder.ToTable("MonthlyBudgets");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId);

            builder.Property(x => x.BudgetAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.LimitAmount)
                .HasPrecision(18, 2);

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.UpdatedDate)
                   .IsRequired(false);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.MonthlyBudgets)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
