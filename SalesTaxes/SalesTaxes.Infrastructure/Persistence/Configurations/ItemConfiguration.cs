using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTaxes.Domain.Entities;

namespace SalesTaxes.Infrastructure.Persistence.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.Price).HasColumnType("numeric(12, 2)");

            builder.HasOne(d => d.IdCategoryNavigation)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Category");
        }
    }
}
