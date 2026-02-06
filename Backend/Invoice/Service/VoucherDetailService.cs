using Invoice.Model;
using Invoice.Repository;
using System.Threading.Tasks;

namespace Invoice.Service
{
    public class VoucherDetailService : IVoucherDetailService
    {
        private readonly IInvoiceRepository<VoucherDetail> _invoiceRepository;
        private readonly AssertService<VoucherDetail> _assertService;

        public VoucherDetailService(IInvoiceRepository<VoucherDetail> invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<VoucherDetail>(invoiceRepository);
        }

        public async Task<VoucherDetail> Add(VoucherDetail entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(VoucherDetail));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<VoucherDetail> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(VoucherDetail));

            return await this._assertService.AssertEntityExist(x=> x.Id.Equals(id), nameof(VoucherDetail));
        }

        public Task<List<VoucherDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VoucherDetail>> GetVoucherDetail(int voucherId)
        {            
            this._assertService.AssertNonZeroId(voucherId, nameof(VoucherDetail));

            List<string> includes = new List<string>() { "Item"};

            return await this._invoiceRepository.GetMultipleInclude(x => x.VoucherId.Equals(voucherId), true, includes);
        }

        public async Task<VoucherDetail> Update(VoucherDetail entity)
        {
            this._assertService.AssertNonZeroId(entity.Id,nameof(VoucherDetail));

            VoucherDetail detailById = await this._assertService.AssertEntityExist(x=> x.Id.Equals(entity.Id), nameof(VoucherDetail));

            detailById.ItemId = entity.ItemId;
            detailById.Amount = entity.Amount;
            detailById.Rate = entity.Rate;
            detailById.InvoiceDetailId = entity.InvoiceDetailId;

            return await this._invoiceRepository.Update(detailById);
        }

        public async Task<List<VoucherDetail>> GetAllByVoucherIds(List<int> voucherIds)
        {
            //TODO: validate Vouchers

            List<string> includes = new List<string>() { "Item", "Voucher" };

            return await this._invoiceRepository.GetMultipleInclude(x=> voucherIds.Contains(x.VoucherId), true, includes);
        }

        public async Task<VoucherDetail> Delete(int id)
        {
            VoucherDetail voucherDetailById = await this.Get(id);

            return await this._invoiceRepository.Delete(voucherDetailById);
        }

        public async Task<List<VoucherDetail>> DeleteByVoucher(int voucherId)
        {
            this._assertService.AssertNonZeroId(voucherId, nameof(VoucherDetail));

            List<VoucherDetail> voucherDetails = await this.GetVoucherDetail(voucherId);

            return await this._invoiceRepository.DeleteAll(voucherDetails);
        }

        public async Task<List<VoucherDetail>> UnLinkVouchersByInvoicecId(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(InvoiceDetail));

            List<VoucherDetail> voucherDetails = await this._invoiceRepository.GetMultiple(x => x.Voucher.InvoiceId.Equals(invoiceId), true);

            List<VoucherDetail> updatedDetails = new List<VoucherDetail>();

            foreach (var item in voucherDetails)
            {
                item.InvoiceDetailId = null;
                VoucherDetail updatedVouchers = await this._invoiceRepository.Update(item);
                updatedDetails.Add(updatedVouchers);
            }

            return updatedDetails;
        }
    }
}
