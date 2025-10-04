namespace Invoice.Model
{
    public class ItemMaster : ICompanyOwnedEntity
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public double? Rate { get; set; }
        public bool? AppliedGST { get; set; }
        public double? Quantity { get; set; }
        public string? Unit { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
