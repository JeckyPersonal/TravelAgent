using Invoice.Model;

namespace Invoice.Service
{
    public interface IVoucherService : IService<VoucherMaster>
    {
        public string GetVoucherNo();

        public Task<List<VoucherMaster>> GetPendingVoucher(int customerId);

        public Task<List<VoucherMaster>> GetAllByInvoice(int invoiceId);

        public Task<VoucherMaster> UpdateInvoiceId(int voucherId, int invoiceId);

        Task<VoucherMaster> UpdateStatus(int voucherId, VoucherStatus status);
        Task<VoucherMaster> GetVoucherByVehicleId(int vehicleId);
        Task<VoucherMaster> GetByVehilceNo(int vehicleDetailId);
        Task<VoucherMaster> GetByDriverId(int driverId);
        Task<VoucherMaster> GetVoucherByCustomer(int customerId);
    }
}
