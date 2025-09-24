using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class CustomerService : IService<Customer>
    {
        private readonly InvoiceRepository<Customer> _invoiceRepository;
        private readonly AssertService<Customer> _assertService;

        public CustomerService(InvoiceRepository<Customer> invoiceRepository, AssertService<Customer> assertService)
        {
            _invoiceRepository = invoiceRepository;
            _assertService = assertService;
        }

        public async Task<Customer> Add(Customer entity)
        {
            this._assertService.AssertZeroId(entity.Id, "Customer");

            Customer existingCustomer = await this._assertService.AssertDuplicationEntity(x => x.Name.Equals(entity.Name), x => x.Id != entity.Id, "Customer");

            return await this._invoiceRepository.Add(entity);

        }

        public async Task<Customer> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, "Customer");

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public Task<List<Customer>> GetAll()
        {
            return this._invoiceRepository.GetAll();
        }

        public async Task<Customer> Update(Customer entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, "Customer");

            Customer existingCustomer = await this._assertService.AssertDuplicationEntity(x => x.Name.Equals(entity.Name), x => x.Id != entity.Id, "Customer");

            existingCustomer.TripRate = entity.TripRate;
            existingCustomer.PhoneNumber = entity.PhoneNumber;
            existingCustomer.Address1 = entity.Address1;
            existingCustomer.Address2 = entity.Address2;
            existingCustomer.Address3 = entity.Address3;
            existingCustomer.CessNo = entity.CessNo;
            existingCustomer.City = entity.City;
            existingCustomer.State = entity.State;
            existingCustomer.Country = entity.Country;

            return await this._invoiceRepository.Update(existingCustomer);
        }
    }
}
