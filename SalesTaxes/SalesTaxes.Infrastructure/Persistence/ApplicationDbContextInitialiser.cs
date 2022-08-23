using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SalesTaxes.Domain.Entities;

namespace SalesTaxes.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            if (!_context.Categories.Any())
            {
                _context.Categories.AddRange(new List<Category>()
                { 
                    new Category() { Id = 1, Name = "General" },
                    new Category() { Id = 2, Name = "Book" },
                    new Category() { Id = 3, Name = "Food" },
                    new Category() { Id = 4, Name = "Medical" }
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Items.Any())
            {
                _context.Items.AddRange(new List<Item>()
                {
                    new Item() { Id = 1, Name = "Book", Price = 12.49m, IdCategory = 2 },
                    new Item() { Id = 2, Name = "Music CD", Price = 14.99m, IdCategory = 1 },
                    new Item() { Id = 3, Name = "Chocolate bar", Price = 0.85m, IdCategory = 3 },
                    new Item() { Id = 4, Name = "Box of chocolates", Price = 10, IdCategory = 3 },
                    new Item() { Id = 5, Name = "Bottle of perfume", Price = 47.50m, IdCategory = 1 },
                    new Item() { Id = 6, Name = "Packet of headache pills", Price = 9.75m, IdCategory = 4 }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
