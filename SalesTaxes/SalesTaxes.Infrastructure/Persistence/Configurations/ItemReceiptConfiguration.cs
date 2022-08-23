using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTaxes.Domain.Entities;

namespace SalesTaxes.Infrastructure.Persistence.Configurations
{
    public class ItemReceiptConfiguration : IEntityTypeConfiguration<ItemReceipt>
    {
        public void Configure(EntityTypeBuilder<ItemReceipt> builder)
        {
            builder.HasKey(e => new { e.Id });

            builder.ToTable("ItemReceipt");

            builder.HasOne(d => d.IdItemNavigation)
                .WithMany(p => p.ItemReceipts)
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemReceipt_Item");

            builder.HasOne(d => d.IdReceiptNavigation)
                .WithMany(p => p.ItemReceipts)
                .HasForeignKey(d => d.IdReceipt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemReceipt_Receipt");
        }
    }
}
