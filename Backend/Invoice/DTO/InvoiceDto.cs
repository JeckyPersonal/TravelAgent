using Invoice.Model;
using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        [Required]
        public string InvoiceNo { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }
        public DriverDto Driver { get; set; }
        public VehicleDetailDto VehicleDetail { get; set; }
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
