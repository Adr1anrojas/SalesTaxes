using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesTaxes.Domain.Entities;

namespace SalesTaxes.Infrastructure.Persistence.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipt");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.SalesTaxes).HasColumnType("numeric(12, 2)");

            builder.Property(e => e.Total).HasColumnType("numeric(12, 2)");
        }
    }
}
