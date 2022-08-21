using MediatR;

namespace SalesTaxes.Application.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery : IRequest<IEnumerable<Category>>;

    public class GetCategoriesQueryHandler: RequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        private List<Category> categories = new List<Category>() 
        { 
            new Category()
            {
                Id = 1,
                Name = "General"
            },
            new Category()
            {
                Id = 2,
                Name = "Book"
            },
            new Category()
            {
                Id = 3,
                Name = "Food"
            },
            new Category()
            {
                Id = 4,
                Name = "Medical"
            }
        };
        protected override IEnumerable<Category> Handle(GetCategoriesQuery request)
        {
            return this.categories;
        }
    }
}
