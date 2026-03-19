namespace Invoice.DTO
{
    public class TenderItemsDto
    {
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public int AverageKM { get; set; }
        public List<int> TotalKm { get; set; }
        public double FixedCost { get; set; }
    }
}
