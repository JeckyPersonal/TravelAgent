using Invoice.Model;

namespace Invoice.Service
{
    public interface IVoucherDetailService : IService<VoucherDetail>
    {
        Task<List<VoucherDetail>> GetVoucherDetail(int voucherId);
    }
}
