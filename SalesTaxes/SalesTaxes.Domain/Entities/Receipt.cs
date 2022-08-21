namespace SalesTaxes.Domain.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime CreatingDate { get; set; }
        public decimal SalesTaxes { get; set; }
        public decimal Total { get; set; }
    }
}
