namespace Invoice.DTO
{
    public class FuelRateDto
    {
        public int Id { get; set; }
        public int TenderID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double FuelCost { get; set; }
    }
}
