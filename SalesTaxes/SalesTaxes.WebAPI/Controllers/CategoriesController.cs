using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesTaxes.Application.Categories.Queries.GetCategories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTaxes.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoriesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await Mediator.Send(new GetCategoriesQuery());
        }
    }
}
