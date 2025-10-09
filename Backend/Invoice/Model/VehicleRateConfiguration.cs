using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Invoice.Model
{
    public enum ConfigurationType
    {
        Vehicle,
        Customer
    }

    public class VehicleRateConfiguration
    {

        public int Id { get; set; }

        public int VehicleId { get; set; }
        public int ItemId { get; set; }
        public int? CustomerId { get; set; }
        public Vehicle Vehicle { get; set; }
        public ItemMaster ItemMaster { get; set; }
        public Customer Customer { get; set; }
        public double Rate { get; set; }
        public ConfigurationType Type { get; set; }
    }
}