using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IInvoiceRepository<PaymentReceived> _paymentRepository;
        private readonly AssertService<PaymentReceived> _assertService;

        public PaymentService(IInvoiceRepository<PaymentReceived> paymentRepository)
        {
            _paymentRepository = paymentRepository;
            _assertService = new AssertService<PaymentReceived>(paymentRepository);
        }

        public async Task<PaymentReceived> Add(PaymentReceived entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(PaymentReceived));

            this._assertService.AssertDuplicationEntity(x=> x.ReferenceNumber.Equals(entity.ReferenceNumber), x => !x.Id.Equals(entity.Id), nameof(PaymentReceived), true);

            return await this._paymentRepository.Add(entity);
        }

        public async Task<PaymentReceived> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(PaymentReceived));

            return await this._paymentRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<PaymentReceived>> GetAll()
        {
            return await this._paymentRepository.GetAll();
        }

        public async Task<List<PaymentReceived>> GetAll(int invoiceId)
        {
            this._assertService.AssertNonZeroId(invoiceId, nameof(PaymentReceived));

            return await this._paymentRepository.GetMultipleInclude(x => true, true, new List<string>() { "Invoice" });
        }

        //public async Task<double> GetTotalPaymentOfInvoice(int invoiceId)
        //{
        //    this._assertService.AssertNonZeroId(invoiceId, nameof(Invoice.Model.Invoice));

        //    List<PaymentReceived> paymentReceiveds = await this._paymentRepository.GetMultiple(x=> x.InvoicePayments.Exists(x=> x.InvoiceId.Equals(invoiceId)), true);

        //    if (paymentReceiveds == null || paymentReceiveds.Count == 0) return 0;

        //    return paymentReceiveds.Sum(x=>x.PaymentAmount);
        //}

        public async Task<PaymentReceived> Update(PaymentReceived entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(PaymentReceived));

            this._assertService.AssertDuplicationEntity(x => x.ReferenceNumber.Equals(entity.ReferenceNumber), x => !x.Id.Equals(entity.Id), nameof(PaymentReceived), true);

            PaymentReceived paymentById = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(PaymentReceived), string.Empty);

            paymentById.ReferenceNumber = entity.ReferenceNumber;
            paymentById.CGST = entity.CGST;
            paymentById.SGST = entity.SGST;
            paymentById.IGST = entity.IGST;
            paymentById.PaymentAmount = entity.PaymentAmount;
            paymentById.ReceivedAmount = entity.ReceivedAmount;
            paymentById.TDS = entity.TDS;

            return await this._paymentRepository.Update(entity);

        }
    }
}
