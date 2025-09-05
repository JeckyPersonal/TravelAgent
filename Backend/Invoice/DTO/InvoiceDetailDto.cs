using Invoice.Model;
using System.ComponentModel.DataAnnotations;

namespace Invoice.DTO
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }

        [Required]
        public double Rate { get; set; }

        [Required]
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
