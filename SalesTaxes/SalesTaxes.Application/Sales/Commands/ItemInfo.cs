using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Application.Sales.Commands
{
    public class ItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }
    }
}
