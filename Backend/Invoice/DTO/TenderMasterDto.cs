using Invoice.Model;

namespace Invoice.DTO
{
    public class TenderMasterDto
    {
        public int Id { get; set; }
        public double FuelContractRate { get; set; }
        public TenderType TenderType { get; set; }
        public double AdjestmentPercentage { get; set; }
        public List<FuelRateDto> FuelRates { get; set; }
    }
}
