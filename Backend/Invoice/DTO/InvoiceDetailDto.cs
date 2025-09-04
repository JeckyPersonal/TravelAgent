using Invoice.Model;

namespace Invoice.DTO
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
