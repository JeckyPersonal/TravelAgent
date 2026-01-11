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
            this._assertService.AssertZeroId(entity.Id, nameof(VehicleRateConfiguration));

            if (entity.Type.Equals(ConfigurationType.Vehicle))
            {
                this._assertService.AssertDuplicationEntity(x => x.ItemId.Equals(entity.ItemId) &&
                    x.VehicleId.Equals(entity.VehicleId) &&
                    x.Type.Equals(entity.Type),
                    x => !x.Id.Equals(entity.Id), nameof(VehicleRateService), false);
            }
            else {
                this._assertService.AssertDuplicationEntity(x => x.ItemId.Equals(entity.ItemId) &&
                    x.VehicleId.Equals(entity.VehicleId) &&
                    x.Type.Equals(entity.Type) &&
                    x.CustomerId.Equals(entity.CustomerId),
                    x => !x.Id.Equals(entity.Id), nameof(VehicleRateService), false);
            }
            var result = await this._invoiceRepository.Add(entity);

            return await this._invoiceRepository.Get(x=> x.Id.Equals(result.Id),true,new List<string>() { "ItemMaster","Customer", "Vehicle", "ItemMaster.Interval" });
        }

        public async Task<VehicleRateConfiguration> Get(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(VehicleRateConfiguration));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(VehicleRateConfiguration));
        }

        public Task<List<VehicleRateConfiguration>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleRateConfiguration>> GetAllRates(int vehicleId, ConfigurationType type)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VehicleRateConfiguration));

            return await this._invoiceRepository.GetMultipleInclude(x=> x.VehicleId.Equals(vehicleId) && x.Type.Equals(type), true, new List<string> { "ItemMaster", "ItemMaster.Interval" });
        }

        public async Task<List<VehicleRateConfiguration>> GetAllCustomerRates(int vehicleId, int customerId, ConfigurationType type)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VehicleRateConfiguration));

            this._assertService.AssertNonZeroId(customerId, nameof(VehicleRateConfiguration));

            return await this._invoiceRepository.GetMultipleInclude(x => x.VehicleId.Equals(vehicleId) && x.CustomerId.Equals(customerId) && x.Type.Equals(type), true, new List<string> { "ItemMaster", "ItemMaster.Interval" });
        }

        public async Task<VehicleRateConfiguration> Update(VehicleRateConfiguration entity)
        {
            this._assertService.AssertNonZeroId(entity.Id, nameof(VehicleRateConfiguration));

            if (entity.Type.Equals(ConfigurationType.Vehicle))
            {

                this._assertService.AssertDuplicationEntity(x => x.ItemId.Equals(entity.ItemId) && 
                    x.VehicleId.Equals(entity.VehicleId), 
                    x => !x.Id.Equals(entity.Id), 
                    nameof(VehicleRateService));
            }
            else {
                this._assertService.AssertDuplicationEntity(x => x.ItemId.Equals(entity.ItemId) &&
                    x.VehicleId.Equals(entity.VehicleId) &&
                    x.CustomerId.Equals(entity.CustomerId),
                    x => !x.Id.Equals(entity.Id),
                    nameof(VehicleRateService));
            }

            VehicleRateConfiguration configurationToUpdate = await this._assertService.AssertEntityExist(x => x.Id.Equals(entity.Id), nameof(VehicleRateConfiguration), "ItemMaster");

            configurationToUpdate.Rate = entity.Rate;
            configurationToUpdate.ItemId = entity.ItemId;

            return await this._invoiceRepository.Update(configurationToUpdate);
        }

        public async Task<VehicleRateConfiguration> GetRateInfo(int vehicleId, int itemId)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VehicleRateConfiguration));

            this._assertService.AssertNonZeroId(itemId, nameof(VehicleRateConfiguration));

            return await this._invoiceRepository.Get(x => x.VehicleId.Equals(vehicleId) && x.ItemId.Equals(itemId) && x.Type.Equals(ConfigurationType.Vehicle), true, new List<string> { "ItemMaster", "ItemMaster.Interval" });
        }

        public async Task<VehicleRateConfiguration> GetCustomerRateForItem(int customerId, int vehicleId, int itemId, ConfigurationType customer)
        {
            this._assertService.AssertNonZeroId(vehicleId, nameof(VehicleRateConfiguration));

            this._assertService.AssertNonZeroId(itemId, nameof(VehicleRateConfiguration));

            this._assertService.AssertNonZeroId(customerId, nameof(VehicleRateConfiguration));

            return await this._invoiceRepository.Get(x => x.CustomerId.Equals(customerId) && x.VehicleId.Equals(vehicleId) && x.ItemId.Equals(itemId), true, new List<string> { "ItemMaster", "ItemMaster.Interval" });
        }

        //public async Task<VehicleRateConfiguration> DeleteRate(int id) 
        //{
        //    var deletingRate = await this.Get(id);
        //    return await this._invoiceRepository.Delete(deletingRate);
        //}

        public async Task<VehicleRateConfiguration> Delete(int id)
        {
            VehicleRateConfiguration vehicleRateConfiguration = await this.Get(id);

            await this._invoiceRepository.Delete(vehicleRateConfiguration);

            return vehicleRateConfiguration;
        }

        public async Task<bool> DeleteAll(List<VehicleRateConfiguration> rateConfigurationByVehicle)
        {
            if (rateConfigurationByVehicle == null || rateConfigurationByVehicle.Count == 0) return false;

            await this._invoiceRepository.DeleteAll(rateConfigurationByVehicle);

            return true;
        }

        public async Task<List<VehicleRateConfiguration>> GetAllCustomerRates(int customerId)
        {
            this._assertService.AssertNonZeroId(customerId, nameof(VehicleRateConfiguration));

            return await this._invoiceRepository.GetMultiple(x => x.CustomerId.Equals(customerId) && x.Type == ConfigurationType.Customer, true);
        }

        public async Task<VehicleRateConfiguration> GetRateByIdWithRelationalEntity(int id)
        {
            this._assertService.AssertNonZeroId(id, nameof(VehicleRateConfiguration));

            return await this._assertService.AssertEntityExist(x => x.Id.Equals(id), nameof(VehicleRateConfiguration), new List<string> { "ItemMaster", "ItemMaster.Interval" });
        }
    }
}
