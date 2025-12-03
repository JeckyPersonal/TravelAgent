using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class InvoicePaymentService : IInvoicePaymentService
    {
        private readonly IInvoiceRepository<InvoicePayment> _invoiceRepository;
        private readonly AssertService<InvoicePayment> _assertService;

        public InvoicePaymentService(IInvoiceRepository<InvoicePayment> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _assertService = new AssertService<InvoicePayment>(invoiceRepository);
        }

        public async Task<InvoicePayment> Add(InvoicePayment entity)
        {
            this._assertService.AssertNonZeroId(entity.InvoiceId, nameof(InvoicePayment));

            this._assertService.AssertNonZeroId(entity.PaymentId, nameof(InvoicePayment));

            return await this._invoiceRepository.Add(entity);
        }

        public Task<InvoicePayment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvoicePayment>> DeleteByPaymentId(int paymentId)
        {
            List<InvoicePayment> invoicePayment = await this.GetAllByPaymentId(paymentId);

            foreach (InvoicePayment invPay in invoicePayment)
            {
                InvoicePayment deletedPayment =  await this._invoiceRepository.Delete(invPay);
            }

            return invoicePayment;
        }

        public Task<InvoicePayment> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoicePayment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvoicePayment>> GetAllByInvoiceId(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(InvoicePayment));

            return await this._invoiceRepository.GetMultiple(x => x.InvoiceId.Equals(invoiceId), true);
        }

        public async Task<List<InvoicePayment>> GetAllByPaymentId(int paymentId)
        {
            this._assertService.AssertNonZeroId(paymentId, nameof(InvoicePayment));

            return await this._invoiceRepository.GetMultiple(x => x.PaymentId.Equals(paymentId), true);
        }

        public Task<InvoicePayment> Update(InvoicePayment entity)
        {
            throw new NotImplementedException();
        }
    }
}
