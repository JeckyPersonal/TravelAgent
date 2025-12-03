using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceRepository<InvoiceDetail> _invoiceRepository;
        private readonly AssertService<InvoiceDetail> _assertService;

        public InvoiceDetailService(IInvoiceRepository<InvoiceDetail> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _assertService = new AssertService<InvoiceDetail>(invoiceRepository);
        }

        public async Task<InvoiceDetail> Add(InvoiceDetail entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(entity));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<InvoiceDetail> Delete(int id)
        {
            InvoiceDetail invoiceDetail = await this.Get(id);

            return await this._invoiceRepository.Delete(invoiceDetail);
        }

        public async Task<List<InvoiceDetail>> DeleteByInvoices(List<int> invoiceId)
        {
            if (invoiceId == null || invoiceId.Count == 0) return new List<InvoiceDetail>();

            List<InvoiceDetail> detailsById = await this._invoiceRepository.GetMultiple(x => invoiceId.Contains(x.InvoiceId), true);

            return await this._invoiceRepository.DeleteAll(detailsById);
        }

        public async Task<InvoiceDetail> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(InvoiceDetail));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(InvoiceDetail));
        }

        public async Task<List<InvoiceDetail>> GetAll(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(InvoiceDetail));

            return await this._invoiceRepository.GetMultipleInclude(x => x.InvoiceId.Equals(invoiceId), true, "Item");
        }

        public async Task<List<InvoiceDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvoiceDetail>> GetInvoiceDetail(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(InvoiceDetail));

            return await this._invoiceRepository.GetMultipleInclude(x => x.InvoiceId.Equals(invoiceId), true, new List<string>() { "Item", "VoucherDetail", "VoucherDetail.Voucher" });
        }

        public async Task<InvoiceDetail> Update(InvoiceDetail entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(InvoiceDetail));

            InvoiceDetail detailById = await this._assertService.AssertEntityExist(x=> x.Id.Equals(entity.Id), nameof(InvoiceDetail));

            detailById.ItemId = entity.ItemId;
            detailById.Rate = entity.Rate;
            detailById.Amount = entity.Amount;
            detailById.AmountBeforeTax = entity.AmountBeforeTax;
            detailById.CGST = entity.CGST;
            detailById.SGST= entity.SGST;
            detailById.IGST = entity.IGST;
            detailById.Quantity = entity.Quantity;

            return await this._invoiceRepository.Update(detailById);
        }
    }
}
