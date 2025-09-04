namespace Invoice.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<VehicleDetail> Vehicles { get; set; }
    }
}
