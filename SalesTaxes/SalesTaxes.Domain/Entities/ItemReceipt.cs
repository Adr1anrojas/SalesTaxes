namespace SalesTaxes.Domain.Entities
{
    public partial class ItemReceipt
    {
        public int Id { get; set; }
        public int IdReceipt { get; set; }
        public int IdItem { get; set; }
        public int Quantity { get; set; }
        public bool IsImported { get; set; }
        public decimal FinalPrice { get; set; }

        public virtual Item IdItemNavigation { get; set; } = null!;
        public virtual Receipt IdReceiptNavigation { get; set; } = null!;
    }
}
