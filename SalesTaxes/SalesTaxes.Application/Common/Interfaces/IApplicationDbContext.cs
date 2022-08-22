using Microsoft.EntityFrameworkCore;
using SalesTaxes.Domain.Entities;

namespace SalesTaxes.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Item> Items { get; }
        DbSet<ItemReceipt> ItemReceipts { get; }
        DbSet<Receipt> Receipts { get; }
        DbSet<Category> Categories { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
