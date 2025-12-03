using AutoMapper;
using Invoice.DTO;
using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Service;

namespace Invoice.Handler.Delete
{
    public class DeleteBank
    {
        private readonly IService<Bank> _bankService;
        private readonly IBankDetailService _bankDetailService;
        private readonly IInvoiceService _invoiceService;
        private readonly InvoiceDBContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteBank(IService<Bank> bankService, IBankDetailService bankDetailService, IInvoiceService invoiceService, InvoiceDBContext dbContext, IMapper mapper)
        {
            _bankService = bankService;
            _bankDetailService = bankDetailService;
            _invoiceService = invoiceService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BankDto> Delete(int bankId)
        {
            List<BankDetail> bankDetail = await this._bankDetailService.GetByBankId(bankId);

            List<int> bankDetailId = bankDetail.Select(x => x.Id).ToList();

            Model.Invoice invoiceByBank = await this._invoiceService.GetByBankId(bankDetailId);
            if (invoiceByBank != null)
                throw new DeleteConflictException("This bank cannot be deleted because it is linked to records in other modules. Please delete or update the related records before attempting to delete the bank.");

            using (var transaction = await this._dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await this.deleteBankDetail(bankId);

                    Bank deletedBank = await this._bankService.Delete(bankId);

                    await transaction.CommitAsync();

                    return this._mapper.Map<BankDto>(deletedBank);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }

        private async Task<bool> deleteBankDetail(int bankId)
        {
            List<BankDetail> bankDetail = await this._bankDetailService.GetByBankId(bankId);

            if (bankDetail == null || bankDetail.Count == 0) return false;

            foreach (BankDetail accountInfo in bankDetail)
            {
                await this._bankDetailService.Delete(accountInfo.Id);
            }

            return true;
        }
    }
}
