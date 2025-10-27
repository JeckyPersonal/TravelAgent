namespace Invoice.Model
{
    public class PaymentReceived :IFinancialYearOwnerEntity
    {
        public int Id { get; set; }
        public DateTime ReveivedDate { get; set; }
        public double PaymentAmount { get; set; }
        public double TDS { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double ReceivedAmount { get; set; }
        public Invoice Invoice { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public int InvoiceId { get; set; }
        public int FinancialYearId { get; set; }
    }
}
