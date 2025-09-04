namespace Invoice.DTO
{
    public class ItemMasterDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public double Rate { get; set; }
        public bool AppliedGST { get; set; }
    }
}
