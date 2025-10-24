using Invoice.Model;
using Invoice.Service;
using System.Threading.Tasks;

namespace Invoice.Handler
{
    public class InvoiceDetailCreator
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IVoucherDetailService _voucherDetailService;
        private readonly InvoiceDBContext _dbContext;

        public InvoiceDetailCreator(InvoiceDBContext invoiceDBContext, IInvoiceDetailService invoiceDetailService, IVoucherDetailService voucherDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
            _voucherDetailService = voucherDetailService;
            _dbContext = invoiceDBContext;
        }

        public async Task<InvoiceDetail> CreateNew(int invoiceId, InvoiceDetail invoiceDetail)
        {
            invoiceDetail.InvoiceId = invoiceId;
            invoiceDetail.Item = null;
            invoiceDetail.Invoice = null;
            invoiceDetail.VoucherDetail = null;

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    InvoiceDetail savedInvoiceDetail = await this._invoiceDetailService.Add(invoiceDetail);

                    VoucherDetail voucerDetailById = await this._voucherDetailService.Get(invoiceDetail.VoucherDetailId.Value);

                    voucerDetailById.InvoiceDetailId = savedInvoiceDetail.Id;

                    VoucherDetail savedVoucherDetail = await this._voucherDetailService.Update(voucerDetailById);

                    await transaction.CommitAsync();
                    return savedInvoiceDetail;
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
