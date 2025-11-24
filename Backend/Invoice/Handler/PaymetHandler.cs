using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler
{
    public class PaymetHandler
    {
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IVoucherService _voucherService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;
        public PaymetHandler(InvoiceDBContext dBContext, IPaymentService paymentService, IInvoiceService invoiceService, IVoucherService voucherService, IMapper mapper)
        {
            _paymentService = paymentService;
            _invoiceService = invoiceService;
            _voucherService = voucherService;
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public async Task<PaymentDto> Received(int invoiceId, int paymentId)
        {
            using (var transaction = this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    Model.Invoice invoiceById = await this._invoiceService.UpdateStatus(invoiceId, VoucherStatus.Payment_Received);

                    Model.InvoicePayment invoicePayment = new InvoicePayment()
                    {
                        InvoiceId = invoiceId,
                        PaymentId = paymentId,
                    };

                    invoiceById.InvoicePayments.Add(invoicePayment);
                    Model.Invoice savedInvoice = await this._invoiceService.Update(invoiceById);

                    List<VoucherMaster> vouchers = await this._voucherService.GetAllByInvoice(invoiceId);

                    if (vouchers.Count > 0)
                    {
                        foreach (VoucherMaster voucherMaster in vouchers)
                        {
                            VoucherMaster savedVoucher = await this._voucherService.UpdateStatus(voucherMaster.Id, VoucherStatus.Payment_Received);
                        }
                    }

                    await this._dbContext.Database.CommitTransactionAsync();

                    return null;

                }
                catch (Exception ex)
                {
                    await this._dbContext.Database.RollbackTransactionAsync();
                    throw ex;
                }
            }
        }

        public async Task<PaymentDto> Remove(int invoiceId, int paymentId)
        {
            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    Model.Invoice invoiceById = await this._invoiceService.UpdateStatus(invoiceId, VoucherStatus.Invoice_Printed);

                    InvoicePayment invoicecPayment = invoiceById.InvoicePayments.Where(x => x.PaymentId == paymentId).FirstOrDefault();

                    List<VoucherMaster> vouchers = await this._voucherService.GetAllByInvoice(invoiceId);

                    if (vouchers.Count > 0)
                    {
                        foreach (VoucherMaster voucher in vouchers)
                        {
                            this._voucherService.UpdateStatus(voucher.Id, VoucherStatus.Invoice_Printed);
                        }
                    }

                    invoiceById.InvoicePayments.Remove(invoicecPayment);

                    Model.Invoice receivedPayment = await this._invoiceService.Update(invoiceById);

                    await this._dbContext.Database.CommitTransactionAsync();

                    return null;
                }
                catch (Exception ex)
                {
                    await this._dbContext.Database.RollbackTransactionAsync();
                    throw ex;
                }
            }
        }
    }
}
