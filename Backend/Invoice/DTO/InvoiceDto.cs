using Invoice.Model;

namespace Invoice.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Driver Driver { get; set; }
        public VehicleDetail VehicleDetail { get; set; }
        public int? StartingKM { get; set; }
        public DateTime StartingTime { get; set; }
        public string StateCode { get; set; }
        public string SACCode { get; set; }
        public double Total { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
    }
}
