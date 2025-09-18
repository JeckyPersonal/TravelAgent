using Invoice.DTO;
using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class BankDetailService : IBankDetailService
    {
        private readonly AssertService<BankDetail> _assertService;
        private readonly IInvoiceRepository<BankDetail> _invoiceRepository;

        public BankDetailService(IInvoiceRepository<BankDetail> invoiceRepository)
        {
            _assertService = new AssertService<BankDetail>(invoiceRepository);
            _invoiceRepository = invoiceRepository;
        }

        public async Task<BankDetail> Add(BankDetail entity)
        {
            this._assertService.AssertZeroId(entity.Id, "BankDetail");

            BankDetail existingDetail = await this._assertService.AssertDuplicationEntity(x => x.AccountNumber.Equals(entity.AccountNumber), x => !x.Id.Equals(entity.Id), "BankdDetail");

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<BankDetail> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, "BankDetail");

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public Task<List<BankDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BankDetail>> GetByBankId(int bankId)
        {
            this._assertService.AssertNonZeroId(bankId, "Bank");

            return await this._invoiceRepository.GetMultiple(x => x.BankId.Equals(bankId), true);
        }

        public async Task<BankDetail> Update(BankDetail entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, "BankDetail");

            BankDetail existingDetail = await this._assertService.AssertDuplicationEntity(x => x.AccountNumber.Equals(entity.AccountNumber), x => !x.Id.Equals(entity.Id), "BankdDetail");

            existingDetail.AccountNumber = entity.AccountNumber;
            existingDetail.IFSCCode = entity.IFSCCode;

            return await this._invoiceRepository.Update(existingDetail);
        }
    }
}
