namespace Invoice.Model
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public ItemMaster Item { get; set; }
        public double? Rate { get; set; }
        public int? Quantity { get; set; }
        public double AmountBeforeTax { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double? Amount { get; set; }
        public int? ItemId { get; set; }
        public string? ItemCategory { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public int? VoucherDetailId { get; set; }
        public VoucherDetail? VoucherDetail { get; set; }
        public string Description { get; set; }
    }
}
