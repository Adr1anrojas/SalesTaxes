using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesTaxes.Application.Common.Interfaces;

namespace SalesTaxes.Application.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery : IRequest<List<Category>>;

    public class GetCategoriesQueryHandler: IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            return categories
                .Select(c => new Category() { Id = c.Id, Name = c.Name })
                .ToList();
        }
    }
}
