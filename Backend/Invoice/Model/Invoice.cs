namespace Invoice.Model
{
    public class Invoice : IFinancialYearOwnerEntity
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Customer Customer { get; set; }
        public BankDetail BankDetail { get; set; }
        public int? StartingKM { get; set; }
        public DateTime StartingTime { get; set; }
        public double? Total { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public double? IGST { get; set; }
        public double Amount { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public List<InvoiceDetail> InvoiceDetail { get; set; }
        public List<VoucherMaster> Vouchers { get; set; }
        public List<PaymentReceived> PaymentReceived { get; set; }
        public int FinancialYearId { get; set; }
        public int CustomerId { get; set; }
        public int BankDetailId { get; set; }
        public VoucherStatus Status { get; set; }
    }
}
