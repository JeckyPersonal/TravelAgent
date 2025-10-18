namespace Invoice.Model
{
    public class VoucherMaster : IFinancialYearOwnerEntity
    {
        public int Id { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleDetail VehicleDetail { get; set; }
        public FinancialYear? FinancialYear { get; set; }
        public Driver? Driver { get; set; }
        public Invoice? Invoice { get; set; }
        public List<VoucherDetail> Details { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int? RegistrationId { get; set; }
        public int FinancialYearId { get; set; }
        public int? DriverId { get; set; }
        public int? InvoiceId { get; set; }
        public string VoucherNo { get; set; }
        public int Days { get; set; }
    }
}
