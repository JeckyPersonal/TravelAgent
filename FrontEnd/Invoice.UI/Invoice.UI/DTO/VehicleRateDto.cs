using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.UI.DTO
{
    internal class VehicleRateDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ItemId { get; set; }
        public string VehicleName { get; set; }
        public string ItemName { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
