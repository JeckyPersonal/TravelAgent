namespace Invoice.Model
{
    public class FuelRate
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double FuelCost { get; set; }
        public int TenderID {  get; set; }
        public TenderMaster Tenders { get; set; }
    }
}
