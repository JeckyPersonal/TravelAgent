using Invoice.Model;
using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class ItemMasterDto
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public ItemType ItemCategory { get; set; }
        public bool SourceVoucher { get; set; }
        public bool SourceInvoice { get; set; }
        public bool SourceSystem { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public bool AppliedGST { get; set; }
        public int? IntervalId { get; set; }
        public string? IntervalName { get; set; }
    }
}
