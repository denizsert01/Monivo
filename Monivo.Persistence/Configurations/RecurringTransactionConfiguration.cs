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
    public sealed class RecurringTransactionConfiguration : IEntityTypeConfiguration<RecurringTransaction>
    {
        public void Configure(EntityTypeBuilder<RecurringTransaction> builder)
        {
            builder.ToTable("RecurringTransactions");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TypeParameter)
                   .WithMany()
                   .HasForeignKey(x => x.TypeParameterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FrequencyParameter)
                   .WithMany()
                   .HasForeignKey(x => x.FrequencyParameterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.UpdatedDate)
                   .IsRequired(false);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.RecurringTransactions)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.RecurringTransactions)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
