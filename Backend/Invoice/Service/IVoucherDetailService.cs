using Invoice.Model;

namespace Invoice.Service
{
    public interface IVoucherDetailService : IService<VoucherDetail>
    {
        Task<List<VoucherDetail>> GetAllByVoucherIds(List<int> voucherIds);
        Task<List<VoucherDetail>> GetVoucherDetail(int voucherId);
    }
}
