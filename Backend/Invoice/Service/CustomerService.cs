using Invoice.Model;
using Invoice.Repository;
using Invoice.Utils;
using Microsoft.Extensions.Logging.Abstractions;

namespace Invoice.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IInvoiceRepository<Customer> _invoiceRepository;
        private readonly IInvoiceRepository<VoucherMaster> _voucherRepository;
        private readonly AssertService<Customer> _assertService;

        public CustomerService(IInvoiceRepository<Customer> invoiceRepository, IInvoiceRepository<VoucherMaster> voucherRespository)
        {
            _invoiceRepository = invoiceRepository;
            _voucherRepository = voucherRespository;
            _assertService = new AssertService<Customer>(this._invoiceRepository);
        }

        public async Task<Customer> Add(Customer entity)
        {
            this._assertService.AssertZeroId(entity.Id, "Customer");

            this._assertService.AssertDuplicationEntity(x => x.Name.Equals(entity.Name), x => x.Id != entity.Id, "Customer");

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

        public async Task<List<Customer>> GetAllCustomerWithPendingVoucher()
        {
            List<VoucherMaster> vouchers = await this._voucherRepository.GetMultipleInclude(x => x.InvoiceId == null || x.InvoiceId.Equals(0), true, "Customer");

            List<Customer> customers = vouchers.Select(x => x.Customer).Distinct(new CustomerEqualityComparer()).ToList();

            return customers;
        }

        public async Task<Customer> Update(Customer entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, "Customer");

            this._assertService.AssertDuplicationEntity(x => x.Name.Equals(entity.Name), x => x.Id != entity.Id, "Customer");

            Customer existingCustomer = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(Customer));

            existingCustomer.TripRate = entity.TripRate;
            existingCustomer.PhoneNumber = entity.PhoneNumber;
            existingCustomer.Address1 = entity.Address1;
            existingCustomer.Address2 = entity.Address2;
            existingCustomer.Address3 = entity.Address3;
            existingCustomer.CessNo = entity.CessNo;
            existingCustomer.City = entity.City;
            existingCustomer.State = entity.State;
            existingCustomer.Country = entity.Country;
            existingCustomer.TaxCategory = entity.TaxCategory;
            existingCustomer.InvoiceFormat = entity.InvoiceFormat;

            return await this._invoiceRepository.Update(existingCustomer);
        }
    }
}
