namespace Invoice.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Driver Driver { get; set; }
        public VehicleDetail VehicleDetail { get; set; }
        public int? StartingKM { get; set; }
        public DateTime StartingTime { get; set; }
        public string? StateCode { get; set; }
        public string? SACCode { get; set; }
        public double? Total { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public double? IGST { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public List<InvoiceDetail> InvoiceDetail { get; set; }
        public int FinancialYearId { get; set; }
        public int? DriverId { get; set; }
        public int? VehicleDetailId { get; set; }
    }
}
