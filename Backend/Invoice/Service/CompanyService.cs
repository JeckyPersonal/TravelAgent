using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class CompanyService : IService<Company>
    {
        private readonly IInvoiceRepository<Company> _invoiceRepository;

        public CompanyService(IInvoiceRepository<Company> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Company> Add(Company entity)
        {
            this.assertNotSavedEntity(entity);

            this.assertCompanyIsNotDuplicate(entity);

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<Company> Update(Company entity)
        {
            this.assertSavedEntity(entity);

            this.assertCompanyIsNotDuplicate(entity);

            Company companyById = await this.assertCompanyIsExist(entity);

            this.updateCompany(entity, companyById);

            return await this._invoiceRepository.Update(entity);
        }

        private void assertNotSavedEntity(Company entity)
        {
            if (entity.Id > 0)
                throw new SavedEntityException("Id should be zero while adding company. Please re-try with zero Id.");
        }

        private void assertCompanyIsNotDuplicate(Company entity)
        {
            Company existingCompany = this._invoiceRepository.Get(x => x.Name.Equals(entity.Name), true).Result;

            if (existingCompany != null && entity.Id != existingCompany.Id)
                throw new DuplicateEntityException($"Company '{entity.Name}' is already exist. Please re-try with different company name.");
        }

        private async Task<Company> assertCompanyIsExist(Company entity)
        {
            Company companyById = await this._invoiceRepository.Get(x => x.Id.Equals(entity.Id), false);

            if (companyById == null)
                throw new RemovedEntityException("");

            return companyById;
        }

        private void updateCompany(Company entity, Company companyById)
        {
            companyById.PANNo = entity.PANNo;
            companyById.PhoneNumber = entity.PhoneNumber;
            companyById.Zip = entity.Zip;
            companyById.Address1 = entity.Address1;
            companyById.Address2 = entity.Address2;
            companyById.Address3 = entity.Address3;
            companyById.City = entity.City;
            companyById.State = entity.State;
            companyById.Country = entity.Country;
            companyById.GSTNo = entity.GSTNo;
            companyById.PANNo = entity.PANNo;
        }

        private void assertSavedEntity(Company entity)
        {
            if (entity.Id == 0)
                throw new SavedEntityException("");
        }

        public async Task<List<Company>> GetAll()
        {
            return await this._invoiceRepository.GetAll();
        }

        public async Task<Company> Get(int id)
        {
            return await this._invoiceRepository.Get(x=> x.Id.Equals(id), true);
        }
    }
}
