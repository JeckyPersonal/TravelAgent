namespace Invoice.Model
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public ItemMaster Item { get; set; }
        public double? Rate { get; set; }
        public int? Quantity { get; set; }
        public double? Amount { get; set; }

        public int? ItemId { get; set; }
    }
}
