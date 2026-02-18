using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class TenderService : ITenderService
    {
        private readonly IInvoiceRepository<TenderMaster> _tenderRepository;
        private readonly AssertService<TenderMaster> _assertService;

        public TenderService(IInvoiceRepository<TenderMaster> invoiceRepository)
        {
            _tenderRepository = invoiceRepository;
            _assertService = new AssertService<TenderMaster>(invoiceRepository);
        }

        public async Task<TenderMaster> Add(TenderMaster entity)
        {
            this.assertNotSavedEntity(entity);

            this.assertCompanyIsNotDuplicate(entity);

            return await this._tenderRepository.Add(entity);
        }

        public async Task<TenderMaster> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TenderMaster> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(TenderMaster));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(TenderMaster));

        }

        public async Task<List<TenderMaster>> GetAll()
        {
            return await this._tenderRepository.GetAll();
        }

        public async Task<TenderMaster> Update(TenderMaster entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(TenderMaster));

            TenderMaster detailById= await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(TenderMaster));

            detailById.FuelContractRate = entity.FuelContractRate;
            detailById.TenderType = entity.TenderType;
            detailById.AdjestmentPercentage = entity.AdjestmentPercentage;
            
            return await this._tenderRepository.Update(detailById);
        }

        public async Task<TenderMaster> GetByCompanyId(int customerId)
        {
            this._assertService.AssertNonZeroId(customerId, "Customer");

            return await this._tenderRepository.Get(x => x.CustomerID.Equals(customerId), true);
        }

        private void assertNotSavedEntity(TenderMaster entity)
        {
            if (entity.Id > 0)
                throw new SavedEntityException("Id should be zero while adding company. Please re-try with zero Id.");
        }

        private void assertCompanyIsNotDuplicate(TenderMaster entity)
        {
            TenderMaster existingCompany = this._tenderRepository.Get(x => x.CustomerID == entity.CustomerID,true).Result;

            if (existingCompany != null && entity.Id != existingCompany.Id)
                throw new DuplicateEntityException($"Tender is already exist. Customer must have only one Tender. Please delete old Tender and add new.");
        }
    }
}
