namespace Invoice.DTO
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime ReveivedDate { get; set; }
        public string ReferenceNumber { get; set; }
        public double PaymentAmount { get; set; }
        public double TDS { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double ReceivedAmount { get; set; }
    }
}
