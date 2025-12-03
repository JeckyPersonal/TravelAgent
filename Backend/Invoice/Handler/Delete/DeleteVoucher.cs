using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteVoucher
    {
        private readonly IInvoiceService _invoiceService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IVoucherService _voucherService;
        private readonly IVoucherDetailService _voucherDetailService;
        private readonly IMapper _mapper;

        public DeleteVoucher(IInvoiceService invoiceService, InvoiceDBContext dbContext, IVoucherService voucherService, IVoucherDetailService voucherDetailService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _dbContext = dbContext;
            _voucherService = voucherService;
            _voucherDetailService = voucherDetailService;
            _mapper = mapper;
        }

        public async Task<VoucherMasterDto> Delete(int voucherId)
        {
            Model.Invoice invoiceOfVoucher = await this._invoiceService.GetInvoiceOfVoucher(voucherId);

            if (invoiceOfVoucher != null)
            {
                throw new DeleteConflictException("This voucher cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the voucher.");
            }

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    List<VoucherDetail> voucherDetails = await this._voucherDetailService.DeleteByVoucher(voucherId);

                    Model.VoucherMaster deletedVoucher = await this._voucherService.Delete(voucherId);

                    await transaction.CommitAsync();

                    return _mapper.Map<VoucherMasterDto>(deletedVoucher);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }

        }
    }
}
