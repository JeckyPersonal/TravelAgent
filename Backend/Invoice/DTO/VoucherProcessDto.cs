namespace Invoice.DTO
{
    public class VoucherProcessDto
    {
        public List<int> VoucherIds { get; set; }
        public List<int> ExcludedDetailId { get; set; }
    }
}
