using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesTaxes.Application.Common.Interfaces;
using SalesTaxes.Domain.Entities;
using SalesTaxes.Infrastructure.Identity;
using System.Reflection;

namespace SalesTaxes.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions, IMediator mediator) : base(options, operationalStoreOptions)
        {
            _mediator = mediator;
        }

        public DbSet<Item> Items => Set<Item>();

        public DbSet<ItemReceipt> ItemReceipts => Set<ItemReceipt>();

        public DbSet<Receipt> Receipts => Set<Receipt>();

        public DbSet<Category> Categories => Set<Category>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
