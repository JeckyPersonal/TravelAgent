using AutoMapper.Configuration.Conventions;

namespace Invoice.Model
{
    public class VoucherDetail
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public int VoucherId { get; set; }
        public ItemMaster Item { get; set; }
        public VoucherMaster Voucher { get; set; }
    }
}
