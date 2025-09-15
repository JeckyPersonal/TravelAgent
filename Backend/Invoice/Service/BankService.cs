using Invoice.Model;
using Invoice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Service
{
    public class BankService : IService<Bank>
    {

        private readonly IInvoiceRepository<Bank> _bankRepository;

        public BankService(IInvoiceRepository<Bank> bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public Task<Bank> Add(Bank entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Bank> Get(int id)
        {
            return await this._bankRepository.Get(x=> x.Id.Equals(id), true);
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
