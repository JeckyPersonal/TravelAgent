using Invoice.Model;
using Invoice.Repository;
using System.Threading.Tasks;

namespace Invoice.Service
{
    public class VehicleRateService : IVehicleRateService
    {
        private readonly IInvoiceRepository<VehicleRateConfiguration> _invoiceRepository;
        private readonly AssertService<VehicleRateConfiguration> _assertService;

        public VehicleRateService(IInvoiceRepository<VehicleRateConfiguration> invoiceRepository)
        {
            this._invoiceRepository = invoiceRepository;
            this._assertService = new AssertService<VehicleRateConfiguration>(invoiceRepository);
        }

        public async Task<VehicleRateConfiguration> Add(VehicleRateConfiguration entity)
        {
            this._assertService.AssertZeroId(entity.Id, nameof(VehicleRateService));

            this._assertService.AssertDuplicationEntity(x=> x.ItemId.Equals(entity.ItemId) && x.VehicleId.Equals(entity.VehicleId), x=> !x.Id.Equals(entity.Id), nameof(VehicleRateService), false);

            return await this._invoiceRepository.Add(entity);
        }

        public async Task<VehicleRateConfiguration> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(VehicleRateService));

            return await this._invoiceRepository.Get(x => x.Id.Equals(id), true);
        }

        public Task<List<VehicleRateConfiguration>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleRateConfiguration>> GetAllRates(int vehicleId)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VehicleRateService));

            return await this._invoiceRepository.GetMultipleInclude(x=> x.VehicleId.Equals(vehicleId), true, "ItemMaster");
        }

        public async Task<VehicleRateConfiguration> Update(VehicleRateConfiguration entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(VehicleRateService));

            this._assertService.AssertDuplicationEntity(x => x.ItemId.Equals(entity.ItemId) && x.VehicleId.Equals(entity.VehicleId), x => !x.Id.Equals(entity.Id), nameof(VehicleRateService));

            VehicleRateConfiguration configurationToUpdate = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(VehicleRateConfiguration), "ItemMaster");

            configurationToUpdate.Rate = entity.Rate;
            configurationToUpdate.ItemId = entity.ItemId;

            return await this._invoiceRepository.Update(configurationToUpdate);
        }
    }
}
