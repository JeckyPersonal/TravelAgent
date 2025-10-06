namespace Invoice.Model
{
    public class VehicleRateConfiguration
    {

        public int Id { get; set; }

        public int VehicleId { get; set; }
        public int ItemId { get; set; }
        public Vehicle Vehicle { get; set; }
        public ItemMaster ItemMaster { get; set; }

        public double Rate { get; set; }
    }
}
