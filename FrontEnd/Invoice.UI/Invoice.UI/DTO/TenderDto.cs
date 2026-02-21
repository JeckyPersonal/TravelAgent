using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    internal class TenderDto
    {
        public int Id { get; set; }
        public double FuelContractRate { get; set; }
        public TenderType TenderType { get; set; }
        public double AdjestmentPercentage { get; set; }
        public List<TenderFuelRateDto> FuelRates { get; set; }
        public int CustomerID { get; set; }
    }
    public enum TenderType
    {
        ABOVE,
        BELOW
    }
}
