using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteVoucherDetail
    {
        private readonly IVoucherDetailService _voucherDetailService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public DeleteVoucherDetail(IVoucherDetailService voucherDetailService, IInvoiceService invoiceService, IMapper mapper)
        {
            _voucherDetailService = voucherDetailService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public async Task<VoucherDetailDto> Delete(int detailId)
        {
            VoucherDetail voucherDetailById = await this._voucherDetailService.Get(detailId);

            Model.Invoice invoiceOfVoucherDetail = await this._invoiceService.GetInvoiceOfVoucher(voucherDetailById.VoucherId);

            if (invoiceOfVoucherDetail != null)
            {
                throw new DeleteConflictException("This voucherDetail cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the voucherDetail.");
            }

            VoucherDetail deletedVoucherDetail = await this._voucherDetailService.Delete(detailId);

            return _mapper.Map<VoucherDetailDto>(deletedVoucherDetail);
        }

    }
}
