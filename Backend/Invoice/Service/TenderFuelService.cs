using Invoice.Exceptions;
using Invoice.Model;
using Invoice.Repository;

namespace Invoice.Service
{
    public class TenderFuelService : ITenderFuelService
    {
        private readonly IInvoiceRepository<FuelRate> _fuelRateRepository;
        private readonly AssertService<FuelRate> _assertService;

        public TenderFuelService(IInvoiceRepository<FuelRate> fuelRateRepository, AssertService<FuelRate> assertService)
        {
            _fuelRateRepository = fuelRateRepository;
            _assertService = assertService;
        }

        public async Task<FuelRate> Add(FuelRate entity)
        {
            this.assertNotSavedEntity(entity);

            this.assertCompanyIsNotDuplicate(entity);

            return await this._fuelRateRepository.Add(entity);
        }

        public async Task<FuelRate> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FuelRate> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(FuelRate));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(FuelRate));
        }

        public async Task<List<FuelRate>> GetAll()
        {
            return await this._fuelRateRepository.GetAll();
        }

        public async Task<FuelRate> Update(FuelRate entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(FuelRate));

            FuelRate detailById = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(FuelRate));

            detailById.FromDate = entity.FromDate;
            detailById.ToDate = entity.ToDate;
            detailById.FuelCost = entity.FuelCost;

            return await this._fuelRateRepository.Update(detailById);
        }

        public async Task<List<FuelRate>> GetByTenderId(int tenderId)
        {
            this._assertService.AssertNonZeroId(tenderId, "Tenders");

            return await this._fuelRateRepository.GetMultiple(x => x.TenderID.Equals(tenderId), true);
        }

        private void assertNotSavedEntity(FuelRate entity)
        {
            if (entity.Id > 0)
                throw new SavedEntityException("Id should be zero while adding company. Please re-try with zero Id.");
        }

        private void assertCompanyIsNotDuplicate(FuelRate entity)
        {
            FuelRate existingCompany = this._fuelRateRepository.Get(x =>x.Id  == entity.Id, true).Result;

            if (existingCompany != null && entity.Id != existingCompany.Id)
                throw new DuplicateEntityException($"Fuel rate deail is already exist. Please delete old Fuel rate and add new.");
        }
    }
}
