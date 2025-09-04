using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Model
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? GSTNo { get; set; }
        public string? PANNo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
        public List<Bank> Banks { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<FinancialYear> FinancialYears { get; set; }
        public List<ItemMaster> Items { get; set; }
        public List<Vehicle> Vehicles { get; set; }

    }
}
