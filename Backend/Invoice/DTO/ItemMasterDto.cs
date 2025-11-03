using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class ItemMasterDto
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public bool AppliedGST { get; set; }
        public int? IntervalId { get; set; }
        public string? IntervalName { get; set; }
    }
}
