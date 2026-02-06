namespace Invoice.Model
{
    public class ItemMaster : ICompanyOwnedEntity
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double? Rate { get; set; }
        public bool? AppliedGST { get; set; }
        public double? Quantity { get; set; }
        public string? Unit { get; set; }
        public ItemType ItemCategory { get; set; }
        public ItemSources ItemSource { get; set; }
        public int CompanyId { get; set; }
        public int? IntervalId { get; set; }
        public Company Company { get; set; }
        public ItemInterval? Interval { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public List<VehicleRateConfiguration> VehicleRates { get; set; }
        public List<VoucherDetail> VoucherDetails { get; internal set; }
    }

    public enum ItemType
    { 
        CHARGE,
        COST
    }

    public enum ItemSources
    {
        VOUCHER,
        INVOICE,
        BOTH,
        SYSTEM
    }
}
