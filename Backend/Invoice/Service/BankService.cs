using Invoice.Model;
using Invoice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Service
{
    public class BankService : IService<Bank>
    {

        private readonly IInvoiceRepository<Bank> _bankRepository;
        private readonly AssertService<Bank> _assertService;

        public BankService(IInvoiceRepository<Bank> bankRepository)
        {
            this._bankRepository = bankRepository;
            this._assertService = new AssertService<Bank>(bankRepository);
        }

        public async Task<Bank> Add(Bank entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(Bank));

            this._assertService.AssertDuplicationEntity(x => x.BankName.Equals(entity.BankName), x => x.Id != entity.Id, entity.BankName);

            return await this._bankRepository.Add(entity);
        }

        public async Task<Bank> Delete(int id)
        {
            Bank bankById = await this.Get(id);

            return await this._bankRepository.Delete(bankById);
        }

        public async Task<Bank> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(Bank));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(Bank));
        }

        public async Task<List<Bank>> GetAll()
        {
            return await this._bankRepository.GetAll();
        }

        public async Task<Bank> Update(Bank entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(Bank));

            this._assertService.AssertDuplicationEntity(x => x.BankName.Equals(entity.BankName), x => x.Id != entity.Id, entity.BankName);

            Bank existingBank = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(Bank));

            existingBank.BankName = entity.BankName;

            return await this._bankRepository.Update(existingBank);
        }
    }
}
