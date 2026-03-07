using Invoice.Model;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Invoice.DTO
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public string VoucherNo { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string Description { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double AmountBeforeGST { get; set; }
        public double Amount { get; set; }
        public int? VoucherDetailId { get; set; }
    }
}
