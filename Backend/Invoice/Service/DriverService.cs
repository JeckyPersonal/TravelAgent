using Invoice.Model;
using Invoice.Repository;
using Microsoft.VisualBasic;

namespace Invoice.Service
{
    public class DriverService : IService<Driver>
    {
        private readonly IInvoiceRepository<Driver> _invoiceRepository;
        private readonly AssertService<Driver> _assertService;

        public DriverService(IInvoiceRepository<Driver> invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<Driver>(this._invoiceRepository);
        }

        public async Task<Driver> Add(Driver entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(Driver));

            Driver existingDriver = await this._assertService.AssertDuplicationEntity(x=> x.DriverName.Equals(entity.DriverName), x=> x.Id!= entity.Id, nameof(Driver));

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<Driver> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(Driver));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public async Task<List<Driver>> GetAll()
        {
            return await this.GetAll();
        }

        public async Task<Driver> Update(Driver entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(Driver));

            Driver existingDriver = await this._assertService.AssertDuplicationEntity(x=> x.DriverName.Equals(entity.DriverName), x=> x.Id!= entity.Id, nameof(Driver));

            existingDriver.LicenseNo = entity.LicenseNo;
            existingDriver.DriverName = entity.DriverName;
            existingDriver.DriverMobile = entity.DriverMobile;

            return await this._invoiceRepository.Update(existingDriver);
        }
    }
}
