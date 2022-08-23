using Microsoft.AspNetCore.Mvc;
using SalesTaxes.Application.Sales.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTaxes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ApiControllerBase
    {

        /// <summary>
        /// Creates a new sales and return the sales taxes and total.
        /// </summary>
        /// <remarks>
        /// **Below you will find the proposed examples for the solution.**
        /// 
        /// **INPUT 1:**
        /// 
        /// **1 Book at 12.49**
        /// 
        /// **1 Book at 12.49**
        /// 
        /// **1 Music CD at 14.99** 
        /// 
        /// **1 Chocolate bar at 0.85**
        /// 
        /// 
        ///     {
        ///         "Items":[
        ///           {
        ///              "Id": 1,
        ///              "Name": "Book",
        ///              "Price": 12.49,
        ///              "IdCategory": 2,
        ///              "Quantity": 2,
        ///              "IsImported": false
        ///           },
        ///           {
        ///              "Id": 2,
        ///              "Name": "Music CD",
        ///              "Price": 14.99,
        ///              "IdCategory": 1,
        ///              "Quantity": 1,
        ///              "IsImported": false
        ///           },
        ///           {
        ///              "Id":3,
        ///              "Name": "Chocolate bar",
        ///              "Price": 0.85,
        ///              "IdCategory": 3,
        ///              "Quantity": 1,
        ///              "IsImported": false
        ///           }
        ///        ]
        ///     }
        ///
        /// **INPUT 2:**
        ///  
        /// **1 Imported box of chocolates at 10.00** 
        ///
        /// **1 Imported bottle of perfume at 47.50** 
        ///  
        ///     {
        ///         "Items":[
        ///            {
        ///               "Id":4,
        ///               "Name":"Box of chocolates",
        ///               "Price":10,
        ///               "IdCategory": 3,
        ///               "Quantity": 1,
        ///               "IsImported": true
        ///            },
        ///            {
        ///               "Id":5,
        ///               "Name":"Bottle of perfume",
        ///               "Price": 47.50,
        ///               "IdCategory":1,
        ///               "Quantity": 1,
        ///               "IsImported":true
        ///           }
        ///        ]
        ///     }
        ///     
        ///  **INPUT 3:**
        ///  
        /// **1 Imported bottle of perfume at 27.99**
        /// 
        /// **1 Bottle of perfume at 18.99**
        /// 
        /// **1 Packet of headache pills at 9.75**
        /// 
        /// **1 Imported box of chocolates at 11.25**
        /// 
        /// **1 Imported box of chocolates at 11.25**
        /// 
        ///     {
        ///         "Items":[
        ///             {
        ///                 "Id":5,
        ///                 "Name":"Bottle of perfume",
        ///                 "Price": 27.99,
        ///                 "IdCategory": 1,
        ///                 "Quantity": 1,
        ///                 "IsImported": true
        ///             },
        ///             {
        ///                 "Id":5,
        ///                 "Name":"Bottle of perfume",
        ///                 "Price": 18.99,
        ///                 "IdCategory": 1,
        ///                 "Quantity": 1,
        ///                 "IsImported": false
        ///             },
        ///             {
        ///                 "Id": 6,
        ///                 "Name":"Packet of headache pills",
        ///                 "Price": 9.75,
        ///                 "IdCategory": 4,
        ///                 "Quantity": 1,
        ///                 "IsImported": false
        ///             },
        ///             {
        ///                 "Id":4,
        ///                 "Name": "Box of chocolates",
        ///                 "Price": 11.25,
        ///                 "IdCategory": 3,
        ///                 "Quantity": 2,
        ///                 "IsImported": true
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <response code="200">Creates a Sale in the system</response>
        /// <response code="400">Unable to create a Sale due to validation error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReceiptDto>> Post([FromBody] CreateSalesCommand command)
        {
            if (command is null || !command.Items.Any())
                return BadRequest();

            return await Mediator.Send(command);
        }
    }
}
