using Invoice.Model;

namespace Invoice.Service
{
    public interface IVoucherService : IService<VoucherMaster>
    {
        public string GetVoucherNo();
    }
}
