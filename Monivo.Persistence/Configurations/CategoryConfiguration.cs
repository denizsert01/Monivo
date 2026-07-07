using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monivo.Domain.Entities;

namespace Monivo.Persistence.Configurations
{
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoryName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.TypeParameter)
                   .WithMany()
                   .HasForeignKey(x => x.TypeParameterId)
                   .OnDelete(DeleteBehavior.Restrict);
           
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.UpdatedDate)
                   .IsRequired(false);
        }
    }
}
