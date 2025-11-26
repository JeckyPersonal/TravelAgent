using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;
using System.Threading.Tasks;

namespace Invoice.Handler
{
    internal class PaymentDetailHandler
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoicePaymentService _invoicePaymentService;
        private readonly IMapper _mapper;

        public PaymentDetailHandler(IInvoiceService invoiceService, IInvoicePaymentService invoicePaymentService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _invoicePaymentService = invoicePaymentService;
            _mapper = mapper;
        }

        public async Task<List<InvoiceDto>> GetInvoicesOfPayment(int paymentId)
        {
            List<InvoicePayment> invoicePayment = await this._invoicePaymentService.GetAllByPaymentId(paymentId);

            if (invoicePayment == null || invoicePayment.Count == 0) return new List<InvoiceDto>();


            List<int> invoiceId = invoicePayment.Select(x=> x.InvoiceId).ToList();

            List<Model.Invoice> invoicesByIds =await this._invoiceService.GetAllInvoice(invoiceId);

            if (invoicesByIds == null || invoicesByIds.Count == 0) return new List<InvoiceDto>();

            return invoicesByIds.Select(x => this._mapper.Map<InvoiceDto>(x)).ToList();
        }
    }
}
