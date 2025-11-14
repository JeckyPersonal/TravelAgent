using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    public class RateInfoDto
    {
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public string Unit { get; set; }
        public string IntervalName { get; set; }
        public int Interval { get; set; }
        public RateSource RateSource { get; set; }
    }

    public enum RateSource
    {
        Item,
        Customer,
        Vehicle
    }
}
