namespace Invoice.Model
{
    public class InvoicePayment
    {
        public Invoice Invoice { get; set; }
        public PaymentReceived Payment { get; set; }

        public int InvoiceId { get; set; }
        public int PaymentId { get; set; }
    }
}
