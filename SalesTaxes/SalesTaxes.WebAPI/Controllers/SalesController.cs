using Microsoft.AspNetCore.Mvc;
using SalesTaxes.Application.Sales.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTaxes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ApiControllerBase
    {
        // POST api/<SalesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReceiptDto>> Post([FromBody] CreateSalesCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
