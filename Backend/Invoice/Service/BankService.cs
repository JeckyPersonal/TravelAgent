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

            Bank existingBank = await this._assertService.AssertDuplicationEntity(x => x.BankName.Equals(entity.BankName), entity.BankName);

            return await this._bankRepository.Add(entity);
        }

        public async Task<Bank> Get(int id)
        {
            return await this._bankRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<Bank>> GetAll()
        {
            return await this._bankRepository.GetAll();
        }

        public Task<Bank> Update(Bank entity)
        {
            throw new NotImplementedException();
        }
    }
}
