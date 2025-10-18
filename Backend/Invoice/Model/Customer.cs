using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Model
{
    public class Customer : ICompanyOwnedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
        public double TripRate { get; set; }
        public string? GSTNo { get; set; }
        public string? PANNo { get; set; }
        public string? CessNo { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<VehicleRateConfiguration> RateConfigurations { get; set; }
        public List<VoucherMaster> Vouchers { get; set; }
    }
}
