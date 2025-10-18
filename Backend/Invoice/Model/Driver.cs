namespace Invoice.Model
{
    public class Driver : ICompanyOwnedEntity
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string? DriverMobile { get; set; }
        public string? LicenseNo { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Invoice> Invoices { get; set; }

        public List<VoucherMaster> Vouchers { get; set; }
    }
}
