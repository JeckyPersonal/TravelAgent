namespace Invoice.DTO
{
    public class VoucherDetailDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string IntervalName { get; set; }
        public int Interval { get; set; }

    }
}
