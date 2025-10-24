using AutoMapper;
using Invoice.DTO;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler
{
    public class InvoiceCreator
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IVoucherService _voucherService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceCreator(IInvoiceService invoiceService, IVoucherService voucherService, InvoiceDBContext dbContext, IMapper autoMapper)
        {
            _invoiceService = invoiceService;
            _voucherService = voucherService;
            _mapper = autoMapper;
            _dbContext = dbContext;
        }

        public async Task<Model.Invoice> CreateNew(InvoiceDto invoiceDto)
        {
            Model.Invoice invoice = this._mapper.Map<Model.Invoice>(invoiceDto);
            invoice.Customer = null;
            invoice.FinancialYear = null;
            invoice.InvoiceNo = this._invoiceService.GetInvoiceNo();
            invoice.StartingTime = DateTime.Now;

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    invoice.Customer = null;
                    invoice.FinancialYear = null;
                    invoice.InvoiceNo = this._invoiceService.GetInvoiceNo();
                    invoice.StartingTime = DateTime.Now;

                    Model.Invoice response = await this._invoiceService.Add(invoice);

                    foreach (int voucherId in invoiceDto.Vouchers)
                    {
                        VoucherMaster savedVoucher = await this._voucherService.UpdateInvoiceId(voucherId, response.Id);
                    }

                    await transaction.CommitAsync();

                    Model.Invoice invoiceById = await this._invoiceService.Get(response.Id);

                    return invoiceById;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
