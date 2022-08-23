using SalesTaxes.Domain.Enums;

namespace SalesTaxes.Application.Sales.Commands
{
    public class ItemInfo : TaxCalculator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }

        public decimal GetSalesTaxes()
        {
            decimal tax = 0;
            if (IdCategory == (int)CategoryEnum.General)
            {
                tax += Math.Round((Price * 0.10m) * 20) / 20;
            }
            if (IsImported)
            {
                tax += Math.Round((Price * 0.05m) * 20) / 20;
            }
            return decimal.Round(tax, 2, MidpointRounding.AwayFromZero) * Quantity;
        }

        public decimal GetTotal()
        {
            return (Price * Quantity) + GetSalesTaxes();
        }
    }

    interface TaxCalculator
    {
        abstract decimal GetSalesTaxes();
        abstract decimal GetTotal();
    }
}
