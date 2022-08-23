namespace SalesTaxes.Domain.Entities
{
    public partial class Item
    {
        public Item()
        {
            ItemReceipts = new HashSet<ItemReceipt>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual ICollection<ItemReceipt> ItemReceipts { get; set; }
    }
}
