using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    internal class TenderFuelRateDto
    {
        public int Id { get; set; }
        public int TenderID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double FuelCost { get; set; }
        public ActionMode Action { get; internal set; }
    }
}
