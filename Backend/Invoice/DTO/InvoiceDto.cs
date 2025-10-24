using Invoice.Model;
using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string? InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? StartingKM { get; set; }
        public DateTime StartingTime { get; set; }
        public double Total { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double Amount { get; set; }
        public List<int> Vouchers { get; set; }
    }
}
