namespace SalesTaxes.Application.Sales.Commands
{
    public class ReceiptDto
    {
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
        public decimal SalesTaxes { get; set; }
        public decimal Total { get; set; }
    }

    public class ItemDto
    {
        public int IdReceipt { get; set; }
        public int IdItem { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
