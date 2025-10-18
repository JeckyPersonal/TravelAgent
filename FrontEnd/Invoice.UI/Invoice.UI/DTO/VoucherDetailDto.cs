
namespace Invoice.UI.DTO
{
    internal class VoucherDetailDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public double Rate { get; set; }
        public string ItemName { get; set; }
        public ActionMode Action { get; internal set; }
    }
}
