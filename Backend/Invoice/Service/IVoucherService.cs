using Invoice.Model;

namespace Invoice.Service
{
    public interface IVoucherService : IService<VoucherMaster>
    {
        public string GetVoucherNo();

        public Task<List<VoucherMaster>> GetPendingVoucher(int customerId);

        public Task<VoucherMaster> UpdateInvoiceId(int voucherId, int invoiceId);
    }
}
