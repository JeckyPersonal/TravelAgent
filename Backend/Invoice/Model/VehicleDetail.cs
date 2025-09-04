namespace Invoice.Model
{
    public class VehicleDetail
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
