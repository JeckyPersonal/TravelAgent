namespace Invoice.Model
{
    public class ItemMaster
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public double? Rate { get; set; }
        public bool? AppliedGST { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
