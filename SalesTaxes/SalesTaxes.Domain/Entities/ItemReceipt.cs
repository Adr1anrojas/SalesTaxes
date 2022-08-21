namespace SalesTaxes.Domain.Entities
{
    public class ItemReceipt
    {
        public int IdReceipt { get; set; }
        public int IdItem { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }
    }
}
