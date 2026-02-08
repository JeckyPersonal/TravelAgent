namespace Invoice.Model
{
    public class TenderMaster : IFinancialYearOwnerEntity
    {
        public int Id { get; set; }
        public double FuelContractRate { get; set; }
        public TenderType TenderType { get; set; }
        public double AdjestmentPercentage { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
        public List<FuelRate> FuelRate { get; set; }
        public int FinancialYearId { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }

    public enum TenderType 
    {
        ABOVE,
        BELOW
    }
}
