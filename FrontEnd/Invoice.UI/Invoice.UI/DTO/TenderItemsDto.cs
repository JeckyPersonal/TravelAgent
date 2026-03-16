using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    public class TenderItemsDto
    {
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public int AverageKM { get; set; }
        public int TotalKm { get; set; }
        public double FixedCost { get; set; }
    }
}
