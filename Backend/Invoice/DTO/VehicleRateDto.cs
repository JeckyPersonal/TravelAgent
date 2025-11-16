using AutoMapper.Configuration.Conventions;
using Invoice.Model;

namespace Invoice.DTO
{
    public class VehicleRateDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ItemId { get; set; }
        public string? VehicleName { get; set; }
        public string? ItemName { get; set; }
        public double Rate { get; set; }
        public int? Quantity { get; set; }
        public string? Unit { get; set; }
        public string? IntervalName { get; set; }
        public int? Interval { get; set; }
    }

    public class CustomerRateDto : VehicleRateDto
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
    }
}
