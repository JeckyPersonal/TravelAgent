using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteInvoiceDetail
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteInvoiceDetail(IInvoiceDetailService invoiceDetailService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _invoiceDetailService = invoiceDetailService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<InvoiceDetailDto> Delete(int id) 
        {
            var invoiceDetail = await _invoiceDetailService.Get(id);

            if (invoiceDetail.VoucherDetailId != null && invoiceDetail.VoucherDetailId != 0)
            { 
                InvoiceDetail deletedDetail = await _invoiceDetailService.Delete(id);

                return _mapper.Map<InvoiceDetailDto>(deletedDetail);
            }
            throw new DeleteConflictException("This invoice detail cannot be deleted because it is linked to voucher modules. Please delete or update the related records before attempting to delete the invoice detail.");
        }
    }
}
