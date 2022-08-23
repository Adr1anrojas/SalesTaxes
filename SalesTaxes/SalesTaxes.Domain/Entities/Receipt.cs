namespace SalesTaxes.Domain.Entities
{
    public partial class Receipt
    {
        public Receipt()
        {
            ItemReceipts = new HashSet<ItemReceipt>();
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal SalesTaxes { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<ItemReceipt> ItemReceipts { get; set; }
    }
}
