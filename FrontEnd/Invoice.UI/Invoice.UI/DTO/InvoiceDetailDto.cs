namespace Invoice.UI.DTO
{
    internal class InvoiceDetailDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double IGST { get; set; }
        public double AmountBeforeGST { get; set; }
        public string VoucherNo { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public ActionMode ActionMode { get; internal set; }
        public int? VoucherDetailId { get; set; }
    }
}
