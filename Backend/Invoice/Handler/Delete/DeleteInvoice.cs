using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteInvoice
    {
        private readonly IInvoicePaymentService _invoicePaymentService;
        private readonly IVoucherDetailService _voucherDetailService;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IVoucherService _voucherService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteInvoice(IInvoicePaymentService invoicePaymentService, IVoucherDetailService voucherDetailService, IInvoiceService invoiceService, IInvoiceDetailService invoiceDetailService, IVoucherService voucherService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _invoicePaymentService = invoicePaymentService;
            _voucherDetailService = voucherDetailService;
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
            _voucherService = voucherService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> Delete(int invoiceId)
        {

            List<Model.InvoicePayment> invoicePaymentByInvoiceId = await this._invoicePaymentService.GetAllByInvoiceId(invoiceId);

            if (invoicePaymentByInvoiceId.Count > 0)
            {
                throw new DeleteConflictException("This invoice cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the invoice.");
            }

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {

                try
                {
                    await this._voucherDetailService.UnLinkVouchersByInvoicecId(invoiceId);

                    await this._voucherService.UnlinkVouchers(invoiceId);

                    await this._invoiceDetailService.DeleteByInvoices(new List<int>() { invoiceId });

                    var deletedInvoice =  await this._invoiceService.Delete(invoiceId);

                    List<VoucherMaster> vouchers = await this._voucherService.GetAllByInvoice(invoiceId);

                    await this.updateVoucherStatus(vouchers, VoucherStatus.New);

                    await transaction.CommitAsync();

                    return _mapper.Map<InvoiceDto>(deletedInvoice);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        private async Task<bool> updateVoucherStatus(List<VoucherMaster> vouchers, VoucherStatus status)
        {
            foreach (VoucherMaster voucherMaster in vouchers)
            {
                voucherMaster.voucherStatus = status;
                voucherMaster.InvoiceId = null;
                await this._voucherService.Update(voucherMaster);
            }

            List<int> voucehrIds = vouchers.Select(x => x.Id).ToList();

            List<VoucherDetail> voucherDetails = await this._voucherDetailService.GetAllByVoucherIds(voucehrIds);

            foreach (VoucherDetail voucherDetail in voucherDetails)
            {
                voucherDetail.InvoiceDetailId = null;

                await this._voucherDetailService.Update(voucherDetail);
            }

            return true;
        }
    }
}
